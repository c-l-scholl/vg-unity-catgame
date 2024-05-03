using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStaminaColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Image stamina;
    private Color32 fullStaminaColor;
    private Color32 decrStaminaColor;
    void Start()
    {
        fullStaminaColor = stamina.color;
        decrStaminaColor = stamina.color;
    }
    public void DecreaseStaminaColor()
    {
        decrStaminaColor[0] += 125;
        if (decrStaminaColor[0] > 255)
        {
            decrStaminaColor[0] = 255;
        }
        stamina.color = decrStaminaColor;
    }

    public void ResetStaminaColor()
    {
        decrStaminaColor = fullStaminaColor;
        stamina.color = fullStaminaColor;
    }
}
