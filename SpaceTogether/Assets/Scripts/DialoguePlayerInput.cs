using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayerInput : MonoBehaviour
{
    private DialogueSystem dialogueSystem;

    public UnityEvent leavesZone;
    public UnityEvent returnsZone;

    public bool inZone { get; private set; }

    public bool selectOption = false;

    public float coolDownEvents = 2f;


    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        leavesZone.AddListener(dialogueSystem.LeftZone);
        returnsZone.AddListener(dialogueSystem.ReturnsZone);
    }

    private void Update()
    {
        if (selectOption)
        {
            dialogueSystem.optionSelected = GetInputOptions();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            inZone = true;
            returnsZone.Invoke();

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!dialogueSystem.talking)
            {
                returnsZone.Invoke();
                inZone = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = false;
            leavesZone.Invoke();
        }

    }

    private int GetInputOptions()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return 3;
        }

        return -1;
    }

    public void ForceZone()
    {
        inZone = true;
        returnsZone.Invoke();
    }
}
