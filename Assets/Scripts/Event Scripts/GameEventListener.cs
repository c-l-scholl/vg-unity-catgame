using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Created by Bret Jackson, stolen by Camden Scholl :)

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent responseEvent;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {   
        gameEvent.UnregisterListener(this);
    }

    public void RaiseEvent()
    {
        responseEvent.Invoke();
    }
}