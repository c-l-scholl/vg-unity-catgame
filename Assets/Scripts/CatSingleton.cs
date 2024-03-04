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

    public BoxCollider2D GetCatCollider()
    {
        return m_singleton.GetComponent<BoxCollider2D>();
    }

    public static CatSingleton GetCatSingleton()
    {
        return m_singleton;
    }
}
