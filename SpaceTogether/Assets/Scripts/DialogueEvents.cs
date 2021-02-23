using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        foreach (var item in SaveDialogueEvents.Instance.events.ToList())
        {
            if (!events.ContainsKey(item.Key))
            {
                events.Add(item.Key, item.Value);
            }
        }

        foreach (var item in eventKey)
        {
            if (!events.ContainsKey(item))
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

    public void ChangeValueTrue(string key)
    {
        if (events.ContainsKey(key))
        {
            events[key] = true;
        }
        else
        {
            Debug.LogError("WRONG CHANGEVALUE CALL");
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

    public void CreateTimer(string key)
    {
       
        activeTimer = true;
        timerKeyName = key;

        events.Add(timerKeyName, false);
    }

    public void SetTime(float timer)
    {
        timeToEvent = timer;
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
        foreach (var item in events.ToList())
        {
            if (!SaveDialogueEvents.Instance.events.ContainsKey(item.Key))
            {
                SaveDialogueEvents.Instance.events.Add(item.Key, item.Value);
                SaveDialogueEvents.Instance.eventKey.Add(item.Key);
            }
        }
    }
}
