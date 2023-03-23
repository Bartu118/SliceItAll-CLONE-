using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnifeController : MonoBehaviour
{

    Rigidbody rb;
    float jump = 10f;
    float move = 7f;
    float gravity = 20;
    
    private GameManager gameManager;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            rb.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.Impulse);
            MoveAndJump();
        }

        if(gameManager.gameFinish || gameManager.gameOver)
        {
            rb.isKinematic= true;
        }
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

        #region TRAMBOLIN
        if (collision.gameObject.tag == "Trambolin")
        {
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        }
        #endregion

        #region ZEMÝNE DEÐÝNCE ÖLME
        if (collision.gameObject.layer==LayerMask.NameToLayer("Plane"))
        {
            Destroy(gameObject);
        }
        #endregion
    }

}
