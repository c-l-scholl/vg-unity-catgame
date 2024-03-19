using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BoxInteraction : MonoBehaviour
{
    private bool interacting;
    public GameObject boxUI;

    void Start()
    {
        interacting = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && !interacting)
        {
            if (other.TryGetComponent(out CatMovement movement)) {
                movement.enabled = false;
            }
            interacting = true;
            boxUI.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out CatMovement movement)) {
            movement.enabled = true;
        }
        interacting = false;
        boxUI.GetComponent<Canvas>().enabled = false;
    }
}