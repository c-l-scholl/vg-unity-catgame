using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GasGuyQuest : MonoBehaviour
{
    public InventoryItemData questItem;
    public Inventory catInventory;
    public UIInventory catBag;
    public DialogueManager dialogueManager;
    public QuestStatus GGQuestStatus;
    // treat curStep as private
    public Step curStep;
    public bool hatesCat = false;
    public Inventory gasGuyInventory;
    private bool isStage4Unlocked = false;
    public UnityEvent UnlockStageFourEvent;
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        GGQuestStatus.Reset();
        gasGuyInventory.ClearItems();
    }

    void AdvanceQuest()
    {
        GGQuestStatus.CheckStepCompletion();
        curStep = GGQuestStatus.GetCurrentStep();
        
        if (GGQuestStatus.IsFirstStep())
        {
            if (catInventory.HasItem(questItem))
            {
                curStep.SetCompletion(true);
                AdvanceQuest();
            }
        }
        dialogueManager.StartDialogue(curStep.dialogueTree);

    }
    public void UnlockStageFour() // Called by the DialogueManager, should change
    {
        if (!isStage4Unlocked)
        {
            if (gasGuyInventory.HasItem(questItem))
            {
                catBag.RemoveItem(0);
                isStage4Unlocked = true;
                UnlockStageFourEvent.Invoke();
            }
        }
    }
}
