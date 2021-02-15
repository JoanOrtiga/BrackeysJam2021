using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayerInput : MonoBehaviour
{
    private DialogueSystem dialogueSystem;

    public Transform player;
    public Transform character2;

    public float range;

    public UnityEvent leavesZone;
    public UnityEvent returnsZone;

    public bool selectOption = false;

    public bool IsInRange()
    {
        float distance = Vector3.Distance(player.position, character2.position);

        return distance < range;
    }

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
            returnsZone.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
}
