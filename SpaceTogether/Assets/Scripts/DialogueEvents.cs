using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    public string[] eventKey;

    public Dictionary<string, bool> events = new Dictionary<string, bool>();

    private bool activeTimer = false;
    private float timeToEvent = 0.0f;
    private string timerKeyName;


    [Header("ONLY FOR TEST")]
    public bool valueChangeTest = false;
    public bool valueTest = false;
    public string keyTest = "";

    private void Awake()
    {
        events = SaveDialogueEvents.Instance.events;

        foreach (var item in eventKey)
        {
            if (events.ContainsKey(item))
            {
                events.Add(item, false);
            }
        }
    }

    public bool CheckValue(string key)
    {
        if (!events.ContainsKey(key))
        {
            Debug.LogError("WRONG CHECKVALUE CALL");
            return true;
        }
        else
        {
            return events[key];
        }
    }

    public void ChangeValue(string key, bool value) 
    {
        if (events.ContainsKey(key))
        {

            events[key] = value;
        }
        else
        {
            Debug.LogError("WRONG CHANGEVALUE CALL");
        }
    }

    public void CreateTimer(float timer, string key)
    {
        timeToEvent = timer;
        activeTimer = true;
        timerKeyName = key;

        events.Add(timerKeyName, false);
    }

    private void Update()
    {
        if (activeTimer)
        {
            timeToEvent -= Time.deltaTime;
            
            if(timeToEvent <= 0)
            {
                activeTimer = false;
                events[timerKeyName] = true;
            }
        }

        if (valueChangeTest)
        {
            ChangeValue(keyTest, valueTest);
        }
    }

    private void OnDestroy()
    {
        foreach (var item in events)
        {
            if (!SaveDialogueEvents.Instance.events.ContainsKey(item.Key))
            {
                SaveDialogueEvents.Instance.events.Add(item.Key, item.Value);
            }
        }
    }
}
