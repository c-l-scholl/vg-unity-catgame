using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlQuest : MonoBehaviour
{
	public GameObject littleGirl;
	public InventoryItemData questItem;
	public GameObject L2; // or the rest of the map or something

	public Inventory catInventory;


	private enum QuestProgress
	{
		QUEST_INCOMPLETE, // Default, hasn't given item to npc
		QUEST_COMPLETE // item has been given
		// HATES_CAT // Player hates


	}
	private QuestProgress currentQuestProg;
	void Start()
	{
		currentQuestProg = QuestProgress.INCOMPLETE;
	}

	public void AdvanceQuest() // needs access to Player's inventory
	{
		// state machine based on quest
		Debug.Log("Received Quest Advance Call");
		switch (currentQuestProg)
		{
			case QuestProgress.QUEST_INCOMPLETE:
				// initial dialogue
				if (catInventory.RemoveItemFromInventory(questItem)) // Player has item
				{
					currentQuestProg = QuestProgress.QUEST_COMPLETE;
					// dialogue
				}
				else // Player doesn't have item
				{
					// dialogue 
				}
				this.AdvanceQuest();
				break;
			case QuestProgress.QUEST_COMPLETE:
				// basic dialogue
				break;
			
		}
	}
}
