using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCatLocation : MonoBehaviour
{
    private Vector3 catStartLocation;

    void Start()
    {
        catStartLocation = CatSingleton.GetCatSingleton().transform.position;
    }

    public IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(1.25f);
    }

    public void SetCatToStartLocation()
    {
        WaitForDelay();
        CatSingleton.GetCatSingleton().transform.position = catStartLocation;
    }
}
