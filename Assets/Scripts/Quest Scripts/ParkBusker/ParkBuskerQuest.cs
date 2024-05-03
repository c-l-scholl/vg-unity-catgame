using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkBuskerQuest : MonoBehaviour
{
    public InventoryItemData questItem;
    public Inventory catInventory;
    public UIInventory catBag;
    public DialogueManager dialogueManager;
    public QuestStatus PBQuestStatus;
    // treat curStep as private
    private Step curStep;
    public Inventory ParkBuskerInventory; // check for quest completion
    private bool IsQuestComplete = false;
    
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        PBQuestStatus.Reset();
        ParkBuskerInventory.ClearItems();
    }

    void AdvanceQuest()
    {
        PBQuestStatus.CheckStepCompletion();
        curStep = PBQuestStatus.GetCurrentStep();
        
        if (PBQuestStatus.IsFirstStep())
        {
            if (catInventory.HasItem(questItem))
            {
                curStep.SetCompletion(true);
                AdvanceQuest();
            }
        }
        dialogueManager.StartDialogue(curStep.dialogueTree);

    }

    public void CompleteDrummerQuest()
    {
        if (!IsQuestComplete)
        {
            catBag.DropItem(0);
            IsQuestComplete = true;
        }
    }
}
