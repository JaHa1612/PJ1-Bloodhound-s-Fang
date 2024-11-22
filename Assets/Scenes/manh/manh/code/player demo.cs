using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdemo : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    // Start is called before the first frame update


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
    }
}
