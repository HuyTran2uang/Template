using System.Collections.Generic;
using System;

public static class EventManager
{
    private static Dictionary<string, Delegate> _eventDictionary = new Dictionary<string, Delegate>();

    /// <summary>
    /// example: Delegate del = new Action<int, float, bool>(MyFunc);
    /// </summary>
    public static void StartListening(string eventName, Delegate listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Delegate thisEvent))
        {
            _eventDictionary[eventName] = Delegate.Combine(thisEvent, listener);
        }
        else
        {
            _eventDictionary.Add(eventName, listener);
        }
    }

    public static void StopListening(string eventName, Delegate listener)
    {
        if (_eventDictionary.TryGetValue(eventName, out Delegate thisEvent))
        {
            _eventDictionary[eventName] = Delegate.Remove(thisEvent, listener);
        }
    }

    public static void TriggerEvent(string eventName, params object[] parameters)
    {
        if (_eventDictionary.TryGetValue(eventName, out Delegate thisEvent))
        {
            thisEvent.DynamicInvoke(parameters);
        }
    }
}
