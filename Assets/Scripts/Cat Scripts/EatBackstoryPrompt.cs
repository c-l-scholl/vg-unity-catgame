using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBackstoryPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sentence[] sentenceArr;
    [SerializeField]
    private DialogueManager dialogueManager;
    [SerializeField]
    private DialogueTree dialogueTree;

    void Start()
    {
        dialogueTree.startingSentence = null;
    }    
    private bool BackStoryChance() 
    {
        float i = Random.Range(0f, 5.0f);
        return i <= 1f;
    }

    public bool RandomBackStory()
    {
        if (!BackStoryChance())
        {
            return false;
        }
        GetComponent<CatMovement>().disableMovement();
        int index = Random.Range(0, sentenceArr.Length);
        dialogueTree.startingSentence = sentenceArr[index];
        dialogueManager.StartDialogue(dialogueTree);
        return true;
    }
}
