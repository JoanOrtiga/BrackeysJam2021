using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [NodeTint("#CCCCFF")]
    public class AwaitBranch : DialogueBaseNode
    {

        public ConditionPattern[] conditions;

        [Output] public DialogueBaseNode pass;
        [Output] public DialogueBaseNode fail;

        [Serializable]
        public struct ConditionPattern
        {
            public Condition condition;
            public bool check;
        }

        private bool success;

        public override void Trigger()
        {
            TestCondition();
        }

        protected async Task TestCondition()
        {
            // Perform condition
            bool success = true;

            DialogueSystem.IsInAwaitBranch = true;

            do
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                success = true;

                for (int i = 0; i < conditions.Length; i++)
                {
                    if(conditions[i].condition != null)
                    {
                        if (conditions[i].condition.Invoke() != conditions[i].check)
                        {
                            success = false;
                            break;
                        }
                    }
               /*     else
                    {
                        Debug.Log(conditions[i].checkEventValue.Invoke(conditions[i].checkEventValue.args.ToString()));
                        Debug.Log(conditions[i].checkEventValue.args.ToString());

                        if (conditions[i].checkEventValue.Invoke(conditions[i].checkEventValue.args.ToString()) != conditions[i].check)
                        {
                            

                            success = false;
                            break;
                        }
                    }*/


                    
                }

            } while (!success);



            //Trigger next nodes
            NodePort port = null;
            if (success)
                port = GetOutputPort("pass");

            if (port == null)
            {
                Debug.LogError("algun dialeg esta fatal");
                return;
            }

            DialogueSystem.IsInAwaitBranch = false;

            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }
    }


    [Serializable]
    public class CheckValue : SerializableCallback<string, bool> { }
}
