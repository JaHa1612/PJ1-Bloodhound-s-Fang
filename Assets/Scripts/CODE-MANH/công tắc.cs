using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class côngtắc : MonoBehaviour
{
    public bool traiphai = false ;
    public int speedthanh = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (traiphai == true)
        {
            transform.Translate(new Vector2(0, 3) * speedthanh * Time.deltaTime);
        } else transform.Translate(new Vector2(0, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            traiphai =true;
        }
        if(collision.gameObject .tag == "Mặt đất")
        {
            traiphai = false;
        }
    }
  
}
