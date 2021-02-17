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

    public float coolDownEvents = 2f;
    private float coolDownTimer;

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

        if(coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(coolDownTimer <= 0)
            {
                returnsZone.Invoke();
            }
              
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coolDownTimer <= 0)
            {
                leavesZone.Invoke();
                coolDownTimer = coolDownEvents;
            }
               
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
