using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By Bret Jackson

[CreateAssetMenu(fileName ="NewDialogue", menuName ="Dialogue/Dialogue Tree")]
public class DialogueTree : ScriptableObject
{
    [Tooltip("The name of the character speaking")]
    public string characterName;
    public Sentence startingSentence;
}