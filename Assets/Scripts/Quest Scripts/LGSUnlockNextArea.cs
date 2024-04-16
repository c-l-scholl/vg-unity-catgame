using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGSUnlockNextArea : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetToStage2Pos()
    {
        transform.position = new Vector3(-77.31f, transform.position.y, transform.position.z);
    }
}
