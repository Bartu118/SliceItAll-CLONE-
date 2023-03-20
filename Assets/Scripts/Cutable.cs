using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour
{

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Sap")
        {
            rb.velocity.magnitude.Equals(0);
        }
    }
}
