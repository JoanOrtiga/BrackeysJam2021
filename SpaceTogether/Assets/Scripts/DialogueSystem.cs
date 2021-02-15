using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using System;

using XNode;

[Serializable]
public class DialogueSystem : MonoBehaviour
{
    private DialoguePlayerInput dialoguePlayerInput;
    private WriteTextOnScreen screenText;

    public SceneGraph chatGraph;
    public SceneGraph interruptionGraph;


    public DialogueGraph chatDialogue;
    public DialogueGraph interruptionDialogue;

    public int optionSelected = -1;

    private void Awake()
    {
        dialoguePlayerInput = FindObjectOfType<DialoguePlayerInput>();
        screenText = GetComponent<WriteTextOnScreen>();
    }
    private void Start()
    {
        chatDialogue = (DialogueGraph)chatGraph.graph;

        chatDialogue.Restart();

        screenText.WriteText(chatDialogue.current.text, chatDialogue.current.timeBetweenChars, chatDialogue.current.timeUntilNextChat);
    }

    private void Update()
    {

    }

    public void Next()
    {
        StartCoroutine(WaitForOption());
       
    }

    public void LeftZone()
    {

    }

    public void ReturnsZone()
    {

    }

    private IEnumerator WaitForOption()
    {
        optionSelected = -1;

        if (chatDialogue.current.answers.Count != 0)
        {
            screenText.WriteOptions(chatDialogue.current.answers);

            dialoguePlayerInput.selectOption = true;

            while (optionSelected == -1)
            {
                yield return null;
            }

            dialoguePlayerInput.selectOption = false;

             screenText.HiglightOption(optionSelected);

              yield return new WaitForSeconds(0.5f);

            screenText.ClearOptions();
           
        }       

        bool noConnections = true;
        foreach (var item in chatDialogue.current.Outputs)
        {
            if (item.IsConnected)
            {
                noConnections = false;
            }
        }

        if (noConnections)
            yield break;

        if (!chatDialogue.current.AnswerQuestion(optionSelected))
            yield break;

        screenText.WriteText(chatDialogue.current.text, chatDialogue.current.timeBetweenChars, chatDialogue.current.timeUntilNextChat);
    }

    public bool UserChose()
    {
        return false;
    }
}