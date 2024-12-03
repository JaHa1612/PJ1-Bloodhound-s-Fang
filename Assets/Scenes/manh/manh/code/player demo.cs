using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdemo : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    public int jumpspeed = 500;
    public int solannhay = 0;
    public Animator Animator;
    private Rigidbody2D rigidbody2d;
    public bool dungyen = false;
    public GameObject GameObject;

    // Start is called before the first frame update
    private void Start()
    {
        Animator = GetComponent<Animator>();
       rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            // x.x = 1;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if(dungyen == true)
        {
            transform.Translate(new Vector2(Speed,0));
        }

        Jump();

    }
    private void Jump()
    {
        if (solannhay >= 2) return;
        else if (Input.GetKeyDown(KeyCode.Space))
        {

            rigidbody2d.AddForce(new Vector2(0, jumpspeed));
            solannhay++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "check")
        {
            Destroy(gameObject, 0.1f);  
        }
        if(collision.gameObject.tag == "tiemap")
        {
            solannhay = 0;
        }
        if (collision.gameObject.tag == "Đứng yên ")
        {
            dungyen = true;
        }
    }

}
