using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnifeController : MonoBehaviour
{

    Rigidbody rb;
    float jump = 10f;
    float move = 5f;
    float gravity = 20;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.down*gravity*Time.deltaTime, ForceMode.Impulse);
        MoveAndJump();

    }

    private void MoveAndJump()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            jump = 15;
            rb.velocity = new Vector3(move,0,0);
            rb.AddTorque(0,0,-180);
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }


        /* 
         * 
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);

            jump = 15;
            rb.velocity = new Vector3(move,0,0);
            rb.AddTorque(0,0,-180);
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        else { jump=-15f; }

        }*/


    }

    private void OnCollisionEnter(Collision collision)
    {
        #region SEKME 
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*7, ForceMode.Impulse);
        if (collision.gameObject.tag==("Cutable"))
        {
            rb.AddForce(Vector3.left * 4, ForceMode.Impulse);
            
        }
        #endregion

    }

}
