using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraldQuest : MonoBehaviour
{
    public InventoryItemData questItem;
    public Inventory catInventory;
    public UIInventory catBag;
    public DialogueManager dialogueManager;
    public QuestStatus GeraldQuestStatus;
    // treat curStep as private
    private Step curStep;
    public Inventory GeraldInventory; // check for quest completion
    
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        GeraldQuestStatus.Reset();
        GeraldInventory.ClearItems();
    }

    void AdvanceQuest()
    {
        GeraldQuestStatus.CheckStepCompletion();
        curStep = GeraldQuestStatus.GetCurrentStep();
        
        if (GeraldQuestStatus.IsFirstStep())
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
