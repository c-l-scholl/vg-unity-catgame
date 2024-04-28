using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestStatus", menuName = "QuestStatus")]
public class QuestStatus : ScriptableObject
{
    [SerializeField]
    private List<Step> steps;

    public int currentStepIndex = 0;

    public Step GetCurrentStep()
    {
        return steps[currentStepIndex];
    }

    public bool IsFirstStep()
    {
        return currentStepIndex == 0;
    }

    public void CheckStepCompletion()
    {
        if (GetCurrentStep().isComplete && currentStepIndex < steps.Count - 1) 
        {
            currentStepIndex++;
        }
    }

    public void Reset()
    {
        currentStepIndex = 0;
        foreach (Step s in steps) 
        {
            s.SetCompletion(false);
        }
    }


}
