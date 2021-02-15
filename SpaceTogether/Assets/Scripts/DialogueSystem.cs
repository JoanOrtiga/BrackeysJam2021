using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private DialoguePlayerInput dialoguePlayerInput;
    private WriteTextOnScreen screenText;

    public DialogueGraph chatGraph;
    public DialogueGraph interruptionGraph;

    private void Awake()
    {
        dialoguePlayerInput = GetComponent<DialoguePlayerInput>();
        screenText = GetComponent<WriteTextOnScreen>();
    }
    private void Start()
    {
        chatGraph.Restart();
        interruptionGraph.Restart();

        screenText.WriteText(chatGraph.current.text);
    }

    private void Update()
    {

    }

    public void LeftZone()
    {
        
    }

    public void ReturnsZone()
    {

    }
}
