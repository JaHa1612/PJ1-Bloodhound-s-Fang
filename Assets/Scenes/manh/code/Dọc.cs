using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thanhdoc5 : MonoBehaviour
{
    [SerializeField] public int tocdobay = 3;
    public bool cham = false;
    [SerializeField] public float diemdung;




    private void Update()
    {
        if(cham == true)
        {
           transform.Translate(new Vector2(0, tocdobay) * Time.deltaTime);
        }
        var x = transform.position;
        if(x.y > diemdung) { cham = false; }
    }
    public void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cham = true;
        }
    }
    
        
    }


