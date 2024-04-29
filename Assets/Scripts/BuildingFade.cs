using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFade : MonoBehaviour
{

    private SpriteRenderer buildingSprite;
    public float fadePercent = 0.75f;

    void Start() {
        buildingSprite = GetComponentInParent<SpriteRenderer>();
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            Color buildColor = buildingSprite.color;
            buildColor.a = 0.75f;
            buildingSprite.color = buildColor;
        }
    }

    void OnTriggerExit2D() {
        Color buildColor = buildingSprite.color;
        buildColor.a = 1f;
        buildingSprite.color = buildColor;
    }
}
