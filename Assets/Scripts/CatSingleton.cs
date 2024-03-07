using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSingleton : MonoBehaviour
{
    public static CatSingleton m_singleton;

    void Awake()
    {
        m_singleton = this;
    }

    public QuestManager GetQuestManager()
    {
        return m_singleton.GetComponent<QuestManager>();
    }

    public static CatSingleton GetCatSingleton()
    {
        return m_singleton;
    }
}
