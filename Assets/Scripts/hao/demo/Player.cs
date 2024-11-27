using UnityEngine;
using System.Collections;

public class Player : Entity
{
    [Header("Move info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private float dashTime;
    [SerializeField] private float dashCoolDown;
    private float dashCoolDownTimer;
    [SerializeField] private float dashtime;


    [Header("attack info")]
    [SerializeField] private float comboTime=.3f;
    private float comboTimeWindow;
    private bool isAttacking;
    private int comboCounter;



    private float xInput;
    private bool isMoving;




    


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {

        base.Update();


        Movement();
        AnimatorController();       

        dashTime -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;


        CheckInput();
        FlipController();

    }

    public void AttackOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
            comboCounter = 0;


    }


    private void CheckInput()
    {
        xInput = UnityEngine.Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.K))
        {
            startAttackEvent();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DashAbility();
        }
    }

    private void startAttackEvent()
    {
        if (!isGrounded)
            return;

        if (comboTimeWindow < 0)
            comboCounter = 0;


        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void DashAbility()
    {
        if (dashCoolDownTimer < 0 && !isAttacking)
        {
            dashCoolDownTimer = dashCoolDown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rb.velocity = new Vector2(0, 0);
        }

        else if (dashTime > 0)
        {
            rb.velocity = new Vector2(facingDir * dashSpeed, 0);

        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorController()
    {

        isMoving = rb.velocity.x != 0;

        anim.SetFloat("Jump/Fall", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isDashing", dashTime > 0);
        anim.SetBool("isAttack", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }
   
    private void FlipController()
    {
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }

    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("takePower"))
        {
            StartCoroutine(TemporaryDashSpeedBoost());
        }
    }

    private IEnumerator TemporaryDashSpeedBoost()
    {
        float originalDashSpeed = dashSpeed; // Store the original speed
        dashSpeed = dashSpeed * 10; // Increase the speed

        yield return new WaitForSeconds(dashtime); // Wait for 1 second

        dashSpeed = originalDashSpeed; // Revert back to the original speed
    }


}
