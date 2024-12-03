using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ct : MonoBehaviour
{
   private Animator Animation;
    public bool tt = false;
    [SerializeField] public GameObject GameObject;
    [SerializeField] public float DUNG;
    
    
    void Start()
    {
        Animation = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tt)
        {
            Animation.SetBool("congtac", true);
            GameObject.transform.Translate(new Vector2(0,3) * Time.deltaTime);
           
        }
        if(GameObject.transform.position.y> DUNG)
        {
            tt = false;
        }
        
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tt = true;
        }
        
    }
       
        }
    
