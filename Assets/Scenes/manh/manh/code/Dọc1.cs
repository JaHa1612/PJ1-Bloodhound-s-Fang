using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Thanhdoc2 : MonoBehaviour
{
    [SerializeField] public bool tocdobay = true;
    [SerializeField] public float diemdung2;
    [SerializeField] public float diemdung1;




    private void Update()
    {
        var x = transform.position;
        if (tocdobay)
        {
            
           transform.Translate(new Vector2(0, 6) * Time.deltaTime);
        }
        
       else
        {
           
            transform.Translate(new Vector2(0,-6)* Time.deltaTime);
        }
        if (x.y > diemdung2)
        {
           tocdobay = false;
        }
        else if (x.y < diemdung1) { tocdobay = true; }
    }
   
    }


