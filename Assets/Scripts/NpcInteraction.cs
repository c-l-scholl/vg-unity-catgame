using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D interactionBox;
    private BoxCollider2D catCollider;

    public UnityEvent interactWithNPC;

    bool activatedQuest = false;
    void Start()
    {
        interactionBox = GetComponent<BoxCollider2D>();
        catCollider = CatSingleton.GetCatSingleton().GetCatCollider();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionBox.IsTouching(catCollider))
        {
            if (!activatedQuest && Input.GetKey(KeyCode.Space) ) 
            {
                interactWithNPC.Invoke();
                activatedQuest = true;
            }
        }
        else 
        {
            activatedQuest = false;
        }
        
    }
    
}
