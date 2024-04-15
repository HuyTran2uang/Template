using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simple.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _instance;
        [SerializeField] private Button _flexButton;
        [SerializeField] private Image _talkerIcon;
        [SerializeField] private TMP_Text _talker, _content;
        private Action _onFlex, _onNext;
        private float _duration;
        private Coroutine _onShowLog;
        private const float TimeEachLetter = 0.05f;
        private bool _isTalking;

        public bool IsTalking => _isTalking;

        public static DialogueManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<DialogueManager>();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _flexButton.onClick.AddListener(() => { _onFlex?.Invoke(); });
        }

        public void Talk(string talker, string content, Action next)
        {
            _flexButton.gameObject.SetActive(true);
            _isTalking = true;
            _duration = TimeEachLetter;
            _talker.text = talker;
            _onShowLog = StartCoroutine(ShowLog(content));
            _onNext = next;
        }

        private IEnumerator ShowLog(string content)
        {
            _content.text = "";
            foreach (var letter in content.ToCharArray())
            {
                _content.text += letter;
                yield return new WaitForSeconds(_duration);
            }
            _onFlex = _onNext;
            _onShowLog = null;
            _isTalking = false;
        }

        public void FastTalk()
        {
            _duration = 0;
        }

        public void OffTalk()
        {
            if (_onShowLog != null)
            {
                StopCoroutine(_onShowLog);
                _onShowLog = null;
            }
            _isTalking = false;
            _flexButton.gameObject.SetActive(false);
        }
    }
}
