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
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        BobQuestStatus.Reset();
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
}
