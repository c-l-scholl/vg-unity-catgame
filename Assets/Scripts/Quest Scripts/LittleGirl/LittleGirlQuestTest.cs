using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LittleGirlQuestTest : MonoBehaviour
{
	public InventoryItemData questItem;
    public Inventory catInventory;
    public UIInventory catBag;
    public DialogueManager dialogueManager;
    public QuestStatus LGQstatus;
    // treat curStep as private
    public Step curStep;
    public Inventory littleGirlInventory; // check for quest completion
    public UnityEvent UnlockStageTwoEvent;
    private bool IsStageTwoUnlocked = false;
    
    
	// public class DialogueTree hatesCat;
    void Start()
    {   
        LGQstatus.Reset();
        littleGirlInventory.ClearItems();
    }

    void AdvanceQuest()
    {
        LGQstatus.CheckStepCompletion();
        curStep = LGQstatus.GetCurrentStep();
        
        if (LGQstatus.IsFirstStep())
        {
            if (catInventory.HasItem(questItem))
            {
                curStep.SetCompletion(true);
                AdvanceQuest();
            }
        }
        dialogueManager.StartDialogue(curStep.dialogueTree);

    }

    public void UnlockStageTwo() // Called by the DialogueManager, should change
    {
        if (!IsStageTwoUnlocked)
        {
            if (littleGirlInventory.HasItem(questItem))
            {
                catBag.RemoveItem(0);
                IsStageTwoUnlocked = true;
                UnlockStageTwoEvent.Invoke();
            }
        }
    }
}

