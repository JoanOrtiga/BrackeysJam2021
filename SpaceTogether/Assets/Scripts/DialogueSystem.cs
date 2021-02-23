using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using UnityEngine.Events;
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

    public bool talking = false;

    private bool answering = false;

    private bool finishedDialogue = false;

    public UnityEvent dialogueFinishedEvent;

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
        if (finishedDialogue)
            return;

        talking = false;

        if (!DialogueSystem.IsInAwaitBranch)
        {
            WriteInterruption();
        }
    }

    public void ReturnsZone()
    {
        if (finishedDialogue)
            return;

        talking = true;

        if (answering)
        {
            StartCoroutine(WaitForOption());
        }
        else if (DialogueSystem.IsInAwaitBranch)
        {
            StartCoroutine(WaitForAwaitBranch());
        }
        else
        {
            WriteText();
        }
    }

    private IEnumerator WaitForOption()
    {
        optionSelected = -1;

        if (chatDialogue.current.answers.Count != 0)
        {
            answering = true;

            screenText.WriteOptions(chatDialogue.current.answers);

            dialoguePlayerInput.selectOption = true;

            while (optionSelected == -1)
            {
                yield return null;
            }

            dialoguePlayerInput.selectOption = false;

            screenText.HiglightOption(optionSelected);

            answering = false;

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
        {
            finishedDialogue = true;
            dialogueFinishedEvent.Invoke();
            yield break;
        }

        if (!chatDialogue.current.AnswerQuestion(optionSelected))
            yield break;

        while (DialogueSystem.IsInAwaitBranch)
        {
            yield return null;
        }

        if (!finishedDialogue)
            WriteText();
    }

    IEnumerator WaitForAwaitBranch()
    {
        while (DialogueSystem.IsInAwaitBranch)
        {
            yield return null;
        }

        WriteText();
    }

    private IEnumerator FindNextInterruption()
    {
        interruptionDialogue.current.AnswerQuestion(0);

        yield return null;

        WriteInterruption();

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

    public void WriteText()
    {
        screenText.WriteText(chatDialogue.current.text, chatDialogue.current.voiceClip, chatDialogue.current.character.name, chatDialogue.current.timeBetweenChars, chatDialogue.current.timeUntilNextChat);
    }

    public void WriteInterruption()
    {
        screenText.WriteInterruption(interruptionDialogue.current.text, interruptionDialogue.current.voiceClip,
           interruptionDialogue.current.character.name, interruptionDialogue.current.timeBetweenChars, interruptionDialogue.current.timeUntilNextChat);
    }

    public void FinishScene()
    {
        finishedDialogue = true;
        dialogueFinishedEvent.Invoke();
    }
}