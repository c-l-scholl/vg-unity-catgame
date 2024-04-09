using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStep", menuName = "Step")]
public class Step : ScriptableObject
{
    [TextArea]
    public string questDescription;
    public bool isComplete = false;
    public DialogueTree dialogueTree;
    public void SetCompletion(bool finished)
    {
        isComplete = finished;
    }
}