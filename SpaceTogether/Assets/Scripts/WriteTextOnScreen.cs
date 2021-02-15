using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteTextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = "xddd";
    }

    public void WriteText(string dialogue)
    {
        text.text = dialogue;
    }
}
