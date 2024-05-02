using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OtherCatQuest : MonoBehaviour
{
	// public InventoryItemData questItem;
    public Inventory catInventory;
    public DialogueManager dialogueManager;
    public QuestStatus dialogueStatus;
    // treat curStep as private
    public Step curStep;
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        dialogueStatus.Reset();
    }

    void AdvanceQuest()
    {
        dialogueStatus.CheckStepCompletion();
        curStep = dialogueStatus.GetCurrentStep();
        dialogueManager.StartDialogue(curStep.dialogueTree);
    }
}


