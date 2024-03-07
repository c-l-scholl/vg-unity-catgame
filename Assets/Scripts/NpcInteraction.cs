using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{

    public UnityEvent interactWithNPC;
    void Start()
    {

    }

    public void TalkToCat()
    {
        interactWithNPC.Invoke();
    }
}
