using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [NodeTint("#CCFFCC")]
    public class Chat : DialogueBaseNode
    {

        public CharacterInfo character;
        [TextArea] public string text;
        public AudioClip voiceClip;
        public float timeBetweenChars = 0.05f;
        public float timeUntilNextChat = 0.5f;
        [Output(dynamicPortList = true)] public List<Answer> answers = new List<Answer>();

        [System.Serializable]
        public class Answer
        {
            public string text;
            //public AudioClip voiceClip;
        }

        public bool AnswerQuestion(int index)
        {
            NodePort port = null;

            if (answers.Count == 0)
            {
                port = GetOutputPort("output");
            }
            else
            {
                if (answers.Count <= index) return false;

                port = GetOutputPort("answers " + index);
            }

            if (port == null) return false;
            else if (port.ConnectionCount == 0) return false;
           
            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }

            return true;
        }

        public override void Trigger()
        {
            (graph as DialogueGraph).current = this;
        }
    }
}