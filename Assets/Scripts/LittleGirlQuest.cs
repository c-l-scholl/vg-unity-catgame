using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlQuest : MonoBehaviour
{
	public GameObject littleGirl;
	public InventoryItemData questItem;
	// Start is called before the first frame update
	public GameObject L2; // or the rest of the map or something

	public Inventory catInventory;


	private enum QuestProgress
	{
		HAVENT_MET,
		ITEM_REQUESTED,
		QUEST_COMPLETE // item has been given

	}
	private QuestProgress currentQuestProg;
	void Start()
	{
		currentQuestProg = QuestProgress.HAVENT_MET;
		catInventory = CatSingleton.GetCatSingleton().GetComponent<CharacterInventory>().inventory;
	}

	public void AdvanceQuest() // needs access to Player's inventory
	{
		// state machine based on quest
		Debug.Log("Received Quest Advance Call");
		switch (currentQuestProg)
		{
			case QuestProgress.HAVENT_MET:
				// initial dialogue
				Debug.Log("Hey there kitty");
				if (catInventory.RemoveItemFromInventory(questItem))
				{
					currentQuestProg = QuestProgress.QUEST_COMPLETE;
					// dialogue
				}
				else
				{
					currentQuestProg = QuestProgress.ITEM_REQUESTED;
					// dialogue
				}
				this.AdvanceQuest();
				break;
			case QuestProgress.ITEM_REQUESTED:
				if (catInventory.RemoveItemFromInventory(questItem))
				{
					currentQuestProg = QuestProgress.QUEST_COMPLETE;
					// dialogue
					this.AdvanceQuest();
				}
				else
				{
					// reminder dialogue
				}
				break;
			case QuestProgress.QUEST_COMPLETE:
				// basic dialogue
				Debug.Log("Wow thank you so much for my letter (i guess)");
				break;
		}
	}
}
