using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    public bool isStartPlace = true;

    public string callEventWhenPickedUp;

    public Vector3 startPos { get; private set; }
    private Quaternion startRot;

    private void Awake()
    {
        

        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void ReLocate()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }

    public void InvokeDialogueEvent(bool value)
    {
        if(callEventWhenPickedUp != "")
        {
            FindObjectOfType<DialogueEvents>().ChangeValue(callEventWhenPickedUp, value);
        }

    }
}

FindObjectOfType<DialogueEvents>().ChangeValue("readCode", true);
