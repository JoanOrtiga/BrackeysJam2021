using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpDistance = 5;
    public LayerMask objectLayerMask;
    public GameObject handCenter;
    public float leaveDistance = 3;
    public GameObject UIPickUp;

    GameObject objectPickUp;
    private bool onHand = false;

    private float timer;
    private bool seenObject;
    private void Start()
    {
        UIPickUp.SetActive(false);
    }

    void Update()
    {

        Ray l_Ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit l_RaycastHit;


        if (Physics.Raycast(l_Ray, out l_RaycastHit, pickUpDistance, objectLayerMask.value))
        {
            
            if (onHand == false)
            {
                UIPickUp.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E) && onHand == false)
            {
                print("Press E to pick Up");
                
                onHand = true;
                objectPickUp = l_RaycastHit.transform.gameObject;
                objectPickUp.transform.position = handCenter.transform.position;
                objectPickUp.transform.SetParent(handCenter.transform);
                objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                timer = 0;
            }
        }
        else
        {
            UIPickUp.SetActive(false);
        }

        if (onHand)
        {
            UIPickUp.SetActive(false);
        }

        if (onHand == true && Input.GetKeyDown(KeyCode.E) && (timer > 0.25))
        {
            UIPickUp.SetActive(false);
            float dist = Vector3.Distance(handCenter.transform.position, objectPickUp.GetComponent<ObjectPlace>().initialPosition);

            

            if (dist > leaveDistance)
            {
                objectPickUp.transform.SetParent(null);
                objectPickUp.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
               
                onHand = false;
            }
            else if(dist < leaveDistance)
            {
                objectPickUp.transform.SetParent(null);
                objectPickUp.transform.position = objectPickUp.GetComponent<ObjectPlace>().initialPosition;
                objectPickUp.transform.rotation = objectPickUp.GetComponent<ObjectPlace>().initialRotation;
                
                onHand = false;

            }
            timer = 0;
           
        }

        timer += Time.deltaTime;

    }



}
