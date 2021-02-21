using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trasmitator : MonoBehaviour
{
    public Material EmisiveOn;
    public Material EmisiveOff;
    public Material MessageOff;

    private DialogueEvents dialogueEvents;

    public MeshRenderer render;

    private bool act4;
    private bool enter; 

    float time = 0;
    float timeEmesive;

    public string dialogueEvent = "InTheTransmissor";

    private void Awake()
    {
        dialogueEvents = FindObjectOfType<DialogueEvents>();
    }

    void Update()
    {
        changeMat();
        timeEmesive += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && act4 == true)
        {
            enter = true;
            dialogueEvents.ChangeValue(dialogueEvent, true);
        }
    }

    private void changeMat()
    {
        if (enter == true && act4 == true)
        {

            time += Time.deltaTime;
        }

        if (time > 20)
        {
            render.material = MessageOff;
        }
        else if (timeEmesive < 1)
        {


            render.material = EmisiveOff;
        }
        else if (timeEmesive < 2)
        {

            render.material = EmisiveOn;
        }
        else if (timeEmesive < 3)
        {
            timeEmesive = 0;
        }
    }
}
