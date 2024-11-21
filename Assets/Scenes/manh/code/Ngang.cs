using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thanhbay : MonoBehaviour
{
    public bool traiphai = true;
    public float trai;
    public float phai;
    public int speedthanh  = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { var x = transform.position;
        if (traiphai)
        {
            transform.Translate(Vector3.right * speedthanh * Time.deltaTime);
        }
        else transform.Translate(Vector3.left * speedthanh * Time.deltaTime);

        if(x.x > phai)
        {
            traiphai = false;
        }
        else if(x.x < trai) { traiphai = true;  }
        
    }
}
