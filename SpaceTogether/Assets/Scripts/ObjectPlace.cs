using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    public bool isStartPlace = true;

    public string callEventWhenPickedUp;

    public Vector3 startPos { get; private set; }
    private Quaternion startRot;

    public bool falseWhenDropped = true;

    private DialogueEvents dialogueEvents;

    private void Awake()
    {
        dialogueEvents = FindObjectOfType<DialogueEvents>();

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
        if (falseWhenDropped)
        {
            if (callEventWhenPickedUp != "")
            {
                dialogueEvents.ChangeValue(callEventWhenPickedUp, value);
            }
        }
        else
        {
            if (callEventWhenPickedUp != "")
            {
                dialogueEvents.ChangeValue(callEventWhenPickedUp, true);
            }
        }

       
        
    }
}