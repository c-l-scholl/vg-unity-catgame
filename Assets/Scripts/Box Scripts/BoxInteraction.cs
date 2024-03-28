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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && !interacting)
        {
            interactWithBox.Invoke();
            interacting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interacting = false;
    }

    
}
