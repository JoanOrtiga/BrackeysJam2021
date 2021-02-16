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
        }
    }

    public void WriteText(string dialogue, float timeBetweenChars, float timeUntilNextChat)
    {
        currentString = dialogue;

        StartCoroutine(CharByChar(timeBetweenChars, timeUntilNextChat));
    }

    IEnumerator CharByChar(float timeBetweenChars, float timeUntilNextChat)
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

            dialogueSystem.Next();
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

}
