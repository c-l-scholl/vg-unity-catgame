using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Bret Jackson

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTree dialogue;
    public DialogueManager dialogueManager;

    public void OnTriggerEnter(Collider other){


        // dialogueManager.StartDialogue(dialogue);
    }
}