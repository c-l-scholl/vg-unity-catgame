using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScreenColorController : MonoBehaviour
{

    public SpriteRenderer screenColor;
    public float changeSpeed;
    public Color nightEndColor;
    public Color sunsetEndColor;

    public void Sunset() {
        StartCoroutine(SunsetChangeScreenColor());
    }

    public void Night() {
        StartCoroutine(NightChangeScreenColor());
    }

    private IEnumerator SunsetChangeScreenColor()
    {
        Color startColor = screenColor.color;
        float tick = 0f;
        while (screenColor.color != sunsetEndColor)
        {
            tick += Time.deltaTime * changeSpeed;
            screenColor.color = Color.Lerp(startColor, sunsetEndColor, tick);
            yield return null;
        }
    }

    private IEnumerator NightChangeScreenColor()
    {
        Color startColor = screenColor.color;
        float tick = 0f;
        while (screenColor.color != nightEndColor)
        {
            tick += Time.deltaTime * changeSpeed;
            screenColor.color = Color.Lerp(startColor, nightEndColor, tick);
            yield return null;
        }
    }
}
