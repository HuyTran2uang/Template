using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopShowTimer : MonoBehaviour
{
    [SerializeField] private float _exist_time_seconds;
    [SerializeField] private float _delay_show_time_seconds;

    private void OnEnable()
    {
        Invoke(nameof(Hide), _exist_time_seconds);
    }

    private void OnDisable()
    {
        Invoke(nameof(Show), _delay_show_time_seconds);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
