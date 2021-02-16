using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace Dialogue
{
    [NodeTint("#CCCCFF")]
    public class BranchNumber : DialogueBaseNode
    {
        public ConditionNumber condition;
        [Output(dynamicPortList = true)] public List<NumberCondition> answers = new List<NumberCondition>();


        [System.Serializable]
        public class NumberCondition
        {
            public int number;
        }

        public override void Trigger()
        {
            int finalNumber = -1;

            int conditionNumber = condition.Invoke();

            for (int i = 0; i < answers.Count; i++)
            {
                Debug.Log(conditionNumber + " " + answers[i].number);

                if (conditionNumber == answers[i].number)
                {
                    finalNumber = answers[i].number;
                    break;
                }
            }

            //Trigger next nodes
            NodePort port = null;

            if (answers.Count == 0)
            {
                port = GetOutputPort("output");
            }
            else
            {
                if (finalNumber == -1)
                    return;

                port = GetOutputPort("answers " + finalNumber);
            }

            if (port == null) return;
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }
    }

    [Serializable]
    public class ConditionNumber : SerializableCallback<int> { }
}