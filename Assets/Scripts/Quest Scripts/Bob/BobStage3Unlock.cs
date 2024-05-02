using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobStage3Unlock : MonoBehaviour
{
    public void SetToStage3Pos()
    {
        transform.position = new Vector3(46.6f, transform.position.y, transform.position.z);
    }
}
