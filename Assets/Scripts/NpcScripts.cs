using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScripts : MonoBehaviour
{
    string name;
    string questObject;
    bool hatesCat;
    int relationship;
    string[] inventory = new string[1];

    // Start is called before the first frame update
    void Start()
    {
        name = "";
        questObject = "";
        hatesCat = false;
    }

    // Add an item to NPC inventory
    void takeObj(string obj)
    {
        inventory[0] = obj;
    }

    // Sets the NPCs QuestObject name
    void setQuestObject(string objectName)
    {
        questObject = objectName;
    }

    // Incrament (increase) the relationship of the NPC
    // with the cat by a certain value i 
    void incRelat(int i)
    {
        relationship += i;
    }

    // Decrament (decrease) the relationship of the NPC
    // with the cat by a certain value i
    // If relationship is below 0, set hatesCat to true
    void decRelat(int i)
    {
        relationship -= i;
        if (relationship <= 0)
        {
            setHatesCat();
        }
    }

    // Sets an NPCs hatred of the cat to true
    void setHatesCat(){
        hatesCat = true; // NPC now hates cat

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
