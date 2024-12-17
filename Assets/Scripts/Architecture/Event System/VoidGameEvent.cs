using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVoidEvent", menuName = "Game Events/Void Event")]
public class VoidGameEvent : ScriptableObject
{
    private List<VoidEventListener> listeners = new List<VoidEventListener>();

    public void Raise()
    {
        // Iterate in reverse to safely handle listener modifications
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(VoidEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(VoidEventListener listener)
    {
        listeners.Remove(listener);
    }
}
