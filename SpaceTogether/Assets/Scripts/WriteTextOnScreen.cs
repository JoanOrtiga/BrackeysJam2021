using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Dialogue;

public class WriteTextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI text;

    public TextMeshProUGUI[] optionText;

    private string currentString;

    DialogueSystem dialogueSystem;

    public bool waitInputToContinue;

    public bool writeNames;

    public AudioSource[] audioCharacters;
    public string[] charNames;

    private void Awake()
    {
        dialogueSystem = GetComponent<DialogueSystem>();

        RestartText();
        ClearOptions();
    }

    public void WriteOptions(List<Chat.Answer> answers)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            optionText[i].text = i+1 + ". " + answers[i].text;
        }
    }

    public void ClearOptions()
    {
        for (int i = 0; i < optionText.Length; i++)
        {
            optionText[i].text = "";
            optionText[i].color = Color.white;
        }

        
    }

    public void WriteText(string dialogue, AudioClip voiceClip, string name, float timeBetweenChars, float timeUntilNextChat)
    {
        StopAllCoroutines();
        RestartText();

        SelectAudio(name, voiceClip);


        if (writeNames)
            currentString = name + ": " + dialogue;
        else
            currentString = dialogue;

        StartCoroutine(CharByChar(timeBetweenChars, timeUntilNextChat, false));
    }

    public void WriteInterruption(string dialogue, AudioClip voiceClip, string name, float timeBetweenChars, float timeUntilNextChat)
    {
        StopAllCoroutines();

        RestartText();
        ClearOptions();

        SelectAudio(name, voiceClip);

        if (writeNames)
            currentString = name + ": " + dialogue;
        else
            currentString = dialogue;

        StartCoroutine(CharByChar(timeBetweenChars, timeUntilNextChat, true));
    }

    IEnumerator CharByChar(float timeBetweenChars, float timeUntilNextChat, bool interruption)
    {


        for (int i = 0; i < currentString.Length; i++)
        {
            text.text += currentString[i];

            yield return new WaitForSeconds(timeBetweenChars);
        }

        if (!waitInputToContinue)
        {
            yield return new WaitForSeconds(timeUntilNextChat);

            RestartText();

            if (!interruption)
                dialogueSystem.Next();
            else
                dialogueSystem.NextInterruption();
        }
    }

    private void RestartText()
    {
        text.text = "";
    }
    
    public void HiglightOption(int index)
    {
        optionText[index].color = Color.yellow;
    }

    private void SelectAudio(string name, AudioClip voiceClip)
    {
        if (voiceClip == null)
            return;

        for (int i = 0; i < audioCharacters.Length; i++)
        {
            if(name == charNames[i])
            {
                audioCharacters[i].clip = voiceClip;
            }
        }
    }
}
