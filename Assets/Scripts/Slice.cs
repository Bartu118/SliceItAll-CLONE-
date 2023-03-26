using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;


public class Slice : MonoBehaviour
{

    public Material materialSlicedSide;
    private GameManager gameManager;
    /*private BoxCollider bxCollider;*/

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        /* bxCollider = GetComponent<BoxCollider>();*/

    }

    private void Update()
    {

    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Cutable"))
        {
            print("deðdi");
            bxCollider.isTrigger = true;
        }
        else
        {
            bxCollider.isTrigger = false;
        }
        
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cutable"))
        {

            SlicedHull sliceobj = Kes(other.gameObject, materialSlicedSide);

            GameObject SlicedObjTop = sliceobj.CreateUpperHull(other.gameObject, materialSlicedSide);
            SlicedObjTop.AddComponent<Rigidbody>();
            SlicedObjTop.AddComponent<BoxCollider>();
            SlicedObjTop.GetComponent<Rigidbody>().AddForce(Vector3.forward * 600);
            SlicedObjTop.GetComponent<BoxCollider>().isTrigger = true;

            GameObject SliceObjDown = sliceobj.CreateLowerHull(other.gameObject, materialSlicedSide);
            SliceObjDown.AddComponent<Rigidbody>();
            SliceObjDown.AddComponent<BoxCollider>();
            SliceObjDown.GetComponent<Rigidbody>().AddForce(Vector3.forward * -600);
            SliceObjDown.GetComponent<BoxCollider>().isTrigger = true;

            Destroy(other.gameObject);
            gameManager.score++;
            
           


        }

    }

    public SlicedHull Kes(GameObject obj, Material mat)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }






}