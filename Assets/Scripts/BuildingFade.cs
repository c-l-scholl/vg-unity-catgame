using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFade : MonoBehaviour
{

    private SpriteRenderer buildingSprite;

    void Start() {
        buildingSprite = GetComponentInParent<SpriteRenderer>();
    }
    void OnTriggerEnter2D() {
        Color buildColor = buildingSprite.color;
        buildColor.a = 0.75f;
        buildingSprite.color = buildColor;
    }

    void OnTriggerExit2D() {
        Color buildColor = buildingSprite.color;
        buildColor.a = 1f;
        buildingSprite.color = buildColor;
    }
}
