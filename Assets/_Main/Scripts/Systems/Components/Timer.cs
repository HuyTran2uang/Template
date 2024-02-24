using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private DateTime _start;
    [SerializeField] private Text _secondText;
    private Action _onUpdate;

    private void OnEnable()
    {
        _start = DateTime.Now;
        if (_secondText != null)
        {
            _onUpdate += ShowText;
        }
    }

    private void Update()
    {
        _onUpdate?.Invoke();
    }

    public void ShowText()
    {
        _secondText.text = $"{(int)Seconds}";
    }

    public double Milliseconds
    {
        get => DateTime.Now.Subtract(_start).TotalMilliseconds;
    }

    public double Seconds
    {
        get => DateTime.Now.Subtract(_start).TotalSeconds;
    }
}