using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simple.Dialogue;
using System.Linq;

public class TestDialogue : MonoBehaviour
{
    public class Log
    {
        public string talkerName;
        public string content;

        public Log(string talkerName, string content)
        {
            this.talkerName = talkerName;
            this.content = content;
        }
    }
    private Log[] _logs =
    {
        new Log("Me", "Hello, i am Huy"),
        new Log("Me", "Can i ask you some question?"),
        new Log("Another", "Ok"),
    };
    private int _logIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(DialogueManager.Instance.IsTalking)
            {
                DialogueManager.Instance.FastTalk();
            }
            else
            {
                Talk();
            }
        }
    }

    private void Talk()
    {
        if (_logIndex < _logs.Length)
        {
            DialogueManager.Instance.Talk(_logs[_logIndex].talkerName, _logs[_logIndex].content, Talk);
            _logIndex++;
        }
        else
        {
            CompletedTalk();
        }
    }

    private void CompletedTalk()
    {
        DialogueManager.Instance.OffTalk();
    }
}
