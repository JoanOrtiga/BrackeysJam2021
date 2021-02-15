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

    public bool IsInRange()
    {
        float distance = Vector3.Distance(player.position, character2.position);

        return distance < range;
    }

    private void Awake()
    {
        dialogueSystem = GetComponent<DialogueSystem>();
        leavesZone.AddListener(dialogueSystem.LeftZone);
        returnsZone.AddListener(dialogueSystem.ReturnsZone);

    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }
}
