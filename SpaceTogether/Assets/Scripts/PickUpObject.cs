using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    public enum Interaction
    {
        pickUp, interact, none
    }


    public float pickUpDistance = 5;
    public LayerMask objectLayerMask;
    public GameObject handCenter;
    public float leaveDistance = 3;

    Transform objectPickUp;
    Rigidbody objectPickUpRigidBody;
    ObjectPlace objectPlace;

    private bool onHand = false;
    private float timer;

    Ray ray;
    RaycastHit rayCastHit;
    bool hitted = false;

    Interaction interaction;

    public Image pickUpIcon;
    public Image interactIcon;

    private int objectLayer;
    private int interactLayer;

    private void Awake()
    {
        objectLayer = LayerMask.NameToLayer("Object");
        interactLayer = LayerMask.NameToLayer("Interactable");
    }

    private void Start()
    {
        StartCoroutine(CheckForObject());
    }

    void Update()
    {
        if (hitted)
        {
            if (interaction == Interaction.interact)
            {
                if (!interactIcon.gameObject.activeSelf)
                    interactIcon.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    rayCastHit.transform.GetComponent<InteractableObject>().Interact(); 
                }
                    
            }
            else if (interaction == Interaction.pickUp)
            {
                if (!pickUpIcon.gameObject.activeSelf)
                    pickUpIcon.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    TakeObject();

                    if (hitted && rayCastHit.transform.GetComponent<Tablet>() != null)
                    {
                        rayCastHit.transform.GetComponent<Tablet>().onHand = true;
                    }
                }
            }
        }
        else
        {
            if (pickUpIcon.gameObject.activeSelf)
                pickUpIcon.gameObject.SetActive(false);

            if (interactIcon.gameObject.activeSelf)
                interactIcon.gameObject.SetActive(false);
        }

        if (onHand && Input.GetKeyDown(KeyCode.E) && (timer > 0.25))
        {
            DropObject();
        }

        timer += Time.deltaTime;
    }

    private void TakeObject()
    {
        onHand = true;

        objectPickUp = rayCastHit.transform;

        objectPickUpRigidBody = objectPickUp.GetComponent<Rigidbody>();
        objectPlace = objectPickUp.GetComponent<ObjectPlace>();

        objectPickUpRigidBody.isKinematic = true;
        objectPickUpRigidBody.constraints = RigidbodyConstraints.FreezeAll;

        objectPickUp.SetParent(handCenter.transform);

        objectPlace.InvokeDialogueEvent(true);

        objectPickUp.position = handCenter.transform.position;
        objectPickUp.localRotation = handCenter.transform.localRotation;

        timer = 0;
    }

    private void PlaceObject()
    {
        float dist = Vector3.Distance(handCenter.transform.position, objectPlace.startPos);

        if(objectPickUp != null)
        {
            objectPickUp.SetParent(null);
            objectPickUpRigidBody.constraints = RigidbodyConstraints.None;
            objectPickUpRigidBody.isKinematic = false;

            if (dist < leaveDistance)
            {
                objectPlace.ReLocate();
            }

            objectPlace.InvokeDialogueEvent(false);
        }

        onHand = false;

        timer = 0;
    }

    IEnumerator CheckForObject()
    {
        while (true)
        {
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            hitted = Physics.Raycast(ray, out rayCastHit, pickUpDistance, objectLayerMask.value);

            if (hitted)
            {
                if (rayCastHit.transform.gameObject.layer == objectLayer)
                {
                    interaction = Interaction.pickUp;
                }
                else if (rayCastHit.transform.gameObject.layer == interactLayer)
                {
                    interaction = Interaction.interact;
                }
            }
            else
            {
                interaction = Interaction.none;
            }

            for (int i = 0; i < 5; i++)
            {
                yield return null;
            }
        }
    }

    public void DropObject()
    {
        PlaceObject();

        if (hitted && rayCastHit.transform.GetComponent<Tablet>() != null)
        {
            rayCastHit.transform.GetComponent<Tablet>().onHand = false;
        }
    }

    public void Eliminate(int x)
    {
        print("HOLA");

        Destroy(objectPickUp.gameObject);

        DropObject();
    }
}

/*
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

                originalPosition = objectPickUp.transform.position;
                originalRotation = objectPickUp.transform.rotation;
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
                objectPickUp.transform.rotation = originalRotation;
                objectPickUp.GetComponent<ObjectPlace>().isStartPlace = true;
                onHand = false;

            }

            timer = 0;
        }

        timer += Time.deltaTime;*/