using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public float pickUpDistance = 5;
    public LayerMask objectLayerMask;
    public GameObject handCenter;
    
    
    
    GameObject objectPickUp;


    private bool inRange = true;
 

    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            Ray l_Ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit l_RaycastHit;


            if (Physics.Raycast(l_Ray, out l_RaycastHit, pickUpDistance, objectLayerMask.value))
            {
                
                
                print(l_RaycastHit.transform.name);
                l_RaycastHit.transform.position = handCenter.transform.position;

                l_RaycastHit.transform.parent = handCenter.transform;

                if (objectPickUp != null)
                {
                   
                
                }

            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectPickUp"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ObjectPickUp"))
        {
            inRange = false;
        }
    }

}
