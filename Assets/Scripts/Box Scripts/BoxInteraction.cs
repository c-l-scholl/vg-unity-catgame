using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements.Experimental;

public class BoxInteraction : MonoBehaviour
{
    private bool interacting;
    public UnityEvent interactWithBox;
    public UnityEvent endBoxInteraction;

    void Start()
    {
        interacting = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && interacting)
        {
            interacting = false;
            endBoxInteraction.Invoke();
        }

        if (Input.GetKey(KeyCode.Space) && !interacting)
        {
            interactWithBox.Invoke();
            interacting = true;
        }
    }
}
