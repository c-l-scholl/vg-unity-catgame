using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlQuest : MonoBehaviour
{
    public GameObject littleGirl;

    public GameObject questItem;
    // Start is called before the first frame update
    public GameObject L2; // or the rest of the map or something


    enum QuestProgress 
    {
        HAVENT_MET,
        ITEM_REQUESTED,
        QUEST_COMPLETE // item has been given

    }
    private QuestProgress currentQuestProg;
    void Start()
    {
        currentQuestProg = QuestProgress.HAVENT_MET;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvanceQuest() // needs access to Player's inventory
    {
        // state machine based on quest
        Debug.Log("Received Quest Advance Call");
        switch ( currentQuestProg )
        {
            case QuestProgress.HAVENT_MET:
                // if player has item
                Debug.Log("Hey there kitty");
                if (CatSingleton.GetCatSingleton().GetInventory().RemoveItemFromInventory(questItem) != null)
                {
                    currentQuestProg = QuestProgress.QUEST_COMPLETE;
                    this.AdvanceQuest();
                }
                // set new CurrentQuestProg
                // else
                break;
            case QuestProgress.ITEM_REQUESTED:
                // if player has item
                //  remove from player inventory, put in girl inventory
                //  set new CurrentQuestProg
                //  dialogue
                // else
                //  dialogue
                break;
            case QuestProgress.QUEST_COMPLETE:
                // basic dialogue
                Debug.Log("Wow thank you so much for my letter (i guess)");
                break;
        }
    }
}
