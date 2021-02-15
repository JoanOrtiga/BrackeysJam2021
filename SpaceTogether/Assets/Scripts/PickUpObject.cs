using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpDistance = 5;
    public LayerMask objectLayerMask;
    public GameObject handCenter;
    public float leaveDistance = 3;


    GameObject objectPickUp;
    private bool onHand = false;
    private Vector3 originalPosition;
    private float timer;

    void Update()
    {

        Ray l_Ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit l_RaycastHit;


        if (Physics.Raycast(l_Ray, out l_RaycastHit, pickUpDistance, objectLayerMask.value))
        {
            
            if (Input.GetKeyDown("e") && onHand == false)
            {
                print("Press E to pick Up");
                onHand = true;
                objectPickUp = l_RaycastHit.transform.gameObject;

                originalPosition = objectPickUp.transform.position;
                objectPickUp.transform.position = handCenter.transform.position;
                objectPickUp.transform.SetParent(handCenter.transform);
                objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                timer = 0;
            }
        }

        if (onHand == true && Input.GetKeyDown("e") && (timer > 0.25))
        {
            float dist = Vector3.Distance(handCenter.transform.position, originalPosition);
            print(dist);
            

            if (dist > leaveDistance || objectPickUp.GetComponent<ObjectPlace>().isStartPlace == false)
            {
                objectPickUp.transform.SetParent(null);
                objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                objectPickUp.GetComponent<ObjectPlace>().isStartPlace = false;
                onHand = false;
            }
            else if(objectPickUp.GetComponent<ObjectPlace>().isStartPlace == true && dist < leaveDistance)
            {
                objectPickUp.transform.SetParent(null);
                objectPickUp.transform.position = originalPosition;
                objectPickUp.GetComponent<ObjectPlace>().isStartPlace = true;
                onHand = false;

            }
            timer = 0;
           
        }

        timer += Time.deltaTime;

    }



}
