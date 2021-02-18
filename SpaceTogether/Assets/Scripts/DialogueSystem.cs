using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using System;

using XNode;

[Serializable]
public class DialogueSystem : MonoBehaviour
{
    public static bool IsInAwaitBranch = false;

    private DialoguePlayerInput dialoguePlayerInput;
    private WriteTextOnScreen screenText;

    public SceneGraph chatGraph;
    public SceneGraph interruptionGraph;

    private DialogueGraph chatDialogue;
    private DialogueGraph interruptionDialogue;

    [HideInInspector] public int optionSelected = -1;

    private void Awake()
    {
        dialoguePlayerInput = FindObjectOfType<DialoguePlayerInput>();
        screenText = GetComponent<WriteTextOnScreen>();
    }
    private void Start()
    {
        chatDialogue = (DialogueGraph)chatGraph.graph;
        interruptionDialogue = (DialogueGraph)interruptionGraph.graph;

        chatDialogue.Restart();
        interruptionDialogue.Restart();
    }

    public void Next()
    {
        StartCoroutine(WaitForOption());
    }

    public void NextInterruption()
    {
        StartCoroutine(FindNextInterruption());
    }

    public void LeftZone()
    {
        screenText.WriteInterruption(interruptionDialogue.current.text,
            interruptionDialogue.current.voiceClip, interruptionDialogue.current.character.name, interruptionDialogue.current.timeBetweenChars, interruptionDialogue.current.timeUntilNextChat);
    }

    public void ReturnsZone()
    {
        screenText.WriteText(chatDialogue.current.text, interruptionDialogue.current.voiceClip, chatDialogue.current.character.name, chatDialogue.current.timeBetweenChars, chatDialogue.current.timeUntilNextChat);
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

        while (DialogueSystem.IsInAwaitBranch)
        {
            yield return null;
        }

        screenText.WriteText(chatDialogue.current.text, interruptionDialogue.current.voiceClip, chatDialogue.current.character.name, chatDialogue.current.timeBetweenChars, chatDialogue.current.timeUntilNextChat);
    }

    private IEnumerator FindNextInterruption()
    {
        interruptionDialogue.current.AnswerQuestion(0);

        yield return null;

        screenText.WriteInterruption(interruptionDialogue.current.text, interruptionDialogue.current.voiceClip,
            interruptionDialogue.current.character.name, interruptionDialogue.current.timeBetweenChars, interruptionDialogue.current.timeUntilNextChat);

        yield return null;
    }

    public bool UserChose()
    {
        return false;
    }


    public int GetRandomPath(int max) 
    {
        StopAllCoroutines();

        return UnityEngine.Random.Range(0, max);
    }
}