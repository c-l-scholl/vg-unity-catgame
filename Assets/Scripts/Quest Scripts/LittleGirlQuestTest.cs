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
	// public class DialogueTree hatesCat;
    void Start()
    {   
        LGQstatus.Reset();
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
}

