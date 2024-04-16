using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LittleGirlQuestTest : MonoBehaviour
{
	public InventoryItemData questItem;
	// public GameObject L2; // or the rest of the map or something
    public Inventory catInventory;
    public DialogueManager dialogueManager;
    public QuestStatus LGQstatus;
    // treat curStep as private
    public Step curStep;
    public UnityEvent UnlockStageTwoEvent;
    private bool IsStageTwoUnlocked = false;
    
    public Inventory littleGirlInventory; // check for quest completion
    
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
                IsStageTwoUnlocked = true;
                UnlockStageTwoEvent.Invoke();
            }
        }
    }
}

