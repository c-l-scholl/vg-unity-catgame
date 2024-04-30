using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LittleGirlQuest : MonoBehaviour
{
	public GameObject littleGirl;
	public InventoryItemData questItem;
	public GameObject L2; // or the rest of the map or something
	public Inventory catInventory;
	private CharacterInventory littleGirlInventory;
    public DialogueManager dialogueManager;
	public DialogueTree questIncomplete;
	public DialogueTree questCompleted;
	public DialogueTree questItemAcquired;
	// public class DialogueTree hatesCat;
	private enum QuestProgress
	{
		QUEST_INCOMPLETE, // Default, hasn't given item to npc, hasn't been acquired
		QUEST_ITEM_ACQUIRED, // player has item
		QUEST_COMPLETE // item has been given
		// HATES_CAT // Player hates
	};
	private QuestProgress currentQuestProg;
	void Start()
	{
		currentQuestProg = QuestProgress.QUEST_INCOMPLETE;
		littleGirlInventory = GetComponent<CharacterInventory>();
	}

	public void AdvanceQuest() // needs access to Player's inventory
	{
		// state machine based on quest
		switch (currentQuestProg)
		{
			case QuestProgress.QUEST_INCOMPLETE:
				// initial dialogue
				if (littleGirlInventory.inventory.HasItem(questItem))
				{
					currentQuestProg = QuestProgress.QUEST_COMPLETE;
					UnlockNextSection();
				}
				else if (catInventory.HasItem(questItem))
				{
					// currentQuestProg = QuestProgress.QUEST_COMPLETE;
					if (dialogueManager.dialogueCanvas.enabled == false)
					{
						dialogueManager.StartDialogue(questItemAcquired);
						this.AdvanceQuest();
					}
					//UnlockNextSection();
				}
				else 
				{
					dialogueManager.StartDialogue(questIncomplete);
				}
				break;
			case QuestProgress.QUEST_COMPLETE:
				// basic dialogue
				dialogueManager.StartDialogue(questCompleted);
				break;
		}
	}

	private void UnlockNextSection()
	{
		L2.SetActive(true);

	}

	public void SetQuestToComplete()
	{
		currentQuestProg = QuestProgress.QUEST_COMPLETE;
	}

	
}
