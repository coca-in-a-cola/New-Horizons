using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Simple Event Channel", menuName = "ScriptableObjects/Event Channels/Simple")]
public class EventChannel : ScriptableObject
{
    public delegate void OnRaiseCallback();
    public OnRaiseCallback OnRaise;

    public void Raise()
    {
        OnRaise?.Invoke();
    }
}