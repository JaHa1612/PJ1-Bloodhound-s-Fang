﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public EntityFx fx { get; private set; }


    #endregion



    [Header("Knockback info")]
    [SerializeField] protected Vector2 knockBackDirection;
    [SerializeField] protected float knockBackDurations;
    protected bool isKnocked;


    [Header("collision info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected LayerMask whatIsWall;



    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;




    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        fx = GetComponent<EntityFx>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }


    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockBack");
        Debug.Log(gameObject.name + "was damage!!");
    }
    protected virtual IEnumerator HitKnockBack()
    {
        isKnocked = true;
        rb.velocity = new Vector2(knockBackDirection.x * -facingDir, knockBackDirection.y);
        yield return new WaitForSeconds(knockBackDurations);
        isKnocked = false;
    }


    #region Collision

    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsWall);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion



    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion



    #region velocity

    public  void SetZeroVelocity()    
    {
        if (isKnocked)
            return;

        rb.velocity = new Vector2(0, 0);
    }

    public  void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked)
            return;


        // Kiểm tra tường trước khi đặt vận tốc ngang
        if (IsWallDetected() && Mathf.Sign(_xVelocity) == facingDir)
        {
            _xVelocity = 0; // Dừng di chuyển theo hướng có tường
        }

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

}
