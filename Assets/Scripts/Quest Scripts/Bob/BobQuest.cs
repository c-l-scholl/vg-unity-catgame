using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BobQuest : MonoBehaviour
{
	public InventoryItemData questItem;
    public Inventory catInventory;
    public UIInventory catBag;
    public DialogueManager dialogueManager;
    public QuestStatus BobQuestStatus;
    // treat curStep as private
    public Step curStep;
    public bool hatesCat = false;
    public Inventory bobInventory;
    private bool isStage3Unlocked = false;
    public UnityEvent UnlockStageThreeEvent;
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        BobQuestStatus.Reset();
        bobInventory.ClearItems();
    }

    void AdvanceQuest()
    {
        BobQuestStatus.CheckStepCompletion();
        curStep = BobQuestStatus.GetCurrentStep();
        
        if (BobQuestStatus.IsFirstStep())
        {
            if (catInventory.HasItem(questItem))
            {
                curStep.SetCompletion(true);
                AdvanceQuest();
            }
        }
        dialogueManager.StartDialogue(curStep.dialogueTree);

    }

    // void HandleHatesCat()
    // {
    //     curStep = BobQuestStatus.SetToHatesCat();
    //     dialogueManager.StartDialogue(curStep.dialogueTree);
    // }   

    public void UnlockStageThree() // Called by the DialogueManager, should change
    {
        if (!isStage3Unlocked)
        {
            if (bobInventory.HasItem(questItem))
            {
                catBag.RemoveItem(0);
                isStage3Unlocked = true;
                UnlockStageThreeEvent.Invoke();
            }
        }
    }
}

