using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirlQuest : MonoBehaviour
{
    public GameObject playerCat; // could use singleton instead
    public GameObject littleGirl;

    public GameObject teddyBear;
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
        switch ( currentQuestProg )
        {
            case QuestProgress.HAVENT_MET:
                // if player has item
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
                break;
        }
    }
}
