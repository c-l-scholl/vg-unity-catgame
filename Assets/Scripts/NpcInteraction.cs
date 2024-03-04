using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D interactionBox;
    private BoxCollider2D catCollider;

    bool activatedQuest = false;
    void Start()
    {
        interactionBox = GetComponent<BoxCollider2D>();
        catCollider = CatSingleton.m_singleton.GetCatCollider();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionBox.IsTouching(catCollider))
        {
            if (!activatedQuest && Input.GetKey(KeyCode.Space) ) // change to have boolean to prevent multiple detection frames
            {
                Debug.Log("Interacted with girl");
                CatSingleton.m_singleton.GetQuestManager().AdvanceQuest(this.gameObject);
                activatedQuest = true;
            }
        }
        else 
        {
            activatedQuest = false;
        }
        
    }
    
}
