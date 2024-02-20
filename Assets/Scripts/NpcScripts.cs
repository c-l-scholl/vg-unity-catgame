using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScripts : MonoBehaviour
{
    string name;
    string questObject;

    // Start is called before the first frame update
    void Start()
    {
        name = "";
        questObject = "";
        
    }

    // Sets the NPCs QuestObject name
    void setQuestObject(string objectName)
    {
        questObject = objectName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
