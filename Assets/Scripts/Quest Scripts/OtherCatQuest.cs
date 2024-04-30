using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OtherCatQuest : MonoBehaviour
{
	// public InventoryItemData questItem;
    public Inventory catInventory;
    public DialogueManager dialogueManager;
    public QuestStatus otherCatStatus;
    // treat curStep as private
    public Step curStep;
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        otherCatStatus.Reset();
    }

    void AdvanceQuest()
    {
        otherCatStatus.CheckStepCompletion();
        curStep = otherCatStatus.GetCurrentStep();
        dialogueManager.StartDialogue(curStep.dialogueTree);
    }
}


