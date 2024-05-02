using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    [SerializeField]
    private Material highlightOutline;
    private Material original;
    private SpriteRenderer sr;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.material;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) {
            sr.material = highlightOutline;
        }
    }

    void OnTriggerExit2D()
    {
        sr.material = original;
    }
}
