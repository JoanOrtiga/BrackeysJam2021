using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpDistance = 5;
    public LayerMask objectLayerMask;
    public GameObject handCenter;



    GameObject objectPickUp;
    private bool onHand = false;


    void Update()
    {
        
        if (onHand == true && Input.GetKeyDown("e"))
        {
            onHand = false;
            objectPickUp.transform.SetParent(null);
            objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        Ray l_Ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit l_RaycastHit;


        if (Physics.Raycast(l_Ray, out l_RaycastHit, pickUpDistance, objectLayerMask.value))
        {
            print("Press E to pick Up");
            if (Input.GetKeyDown("e") && onHand == false)
            {
                onHand = true;
                objectPickUp = l_RaycastHit.transform.gameObject;
                objectPickUp.transform.position = handCenter.transform.position;
                objectPickUp.transform.SetParent(handCenter.transform);
                objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
              
            }
        }


    }



}
