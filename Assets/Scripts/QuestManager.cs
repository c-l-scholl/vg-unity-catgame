using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Component that tracks all quests associated with NPC, whether they have started or not
// Could be on cat, could be its own game object
// Designer tunes all possible quests on this component
// Monobehavior is always serializable, but not new classes or structs
// add serializable to save those
[Serializable]
public struct QuestPlusNPC
{
    public GameObject Quest;
    public GameObject NPC;
}

public class QuestManager : MonoBehaviour
{
    public QuestPlusNPC[] quests; // list of structs better than dictionary

    public void AdvanceQuest(GameObject npc)
    {
        // search map for matching npc
        // call method on paired quest
    }
}

// e