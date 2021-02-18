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

    public bool valueChangeTest = false;
    public bool valueTest = false;
    public string keyTest = "";

    private void Awake()
    {
        foreach (var item in eventKey)
        {
            events.Add(item, false);
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
}
