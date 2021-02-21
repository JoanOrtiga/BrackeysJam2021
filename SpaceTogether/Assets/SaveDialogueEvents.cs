using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SaveDialogueEvents : MonoBehaviour
{
    private static SaveDialogueEvents _instance;

    public static SaveDialogueEvents Instance { get { return _instance; } }


    public List<string> eventKey;

    public Dictionary<string, bool> events = new Dictionary<string, bool>();


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);

            foreach (var item in eventKey)
            {
                events.Add(item, false);
            }
        }
    }
}
