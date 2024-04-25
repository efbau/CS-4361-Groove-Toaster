using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent<int>> eventDictionary;

    private static IntEventManager eventManager;

    public static IntEventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(IntEventManager)) as IntEventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active Event Manager script on a GameObject in your scene");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent<int>>();
        }
    }

    public static void StartListening(string eventName, UnityAction<int> listener)
    {
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<int>();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<int> listener)
    {
        if (eventManager == null) return;
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, int val)
    {
        UnityEvent<int> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(val);
        }
    }
}
