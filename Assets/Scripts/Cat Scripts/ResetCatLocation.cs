using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCatLocation : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 catStartLocation;
    void Start()
    {
        catStartLocation = CatSingleton.GetCatSingleton().transform.position;
    }

    // Update is called once per frame
    public void SetCatToStartLocation()
    {
        CatSingleton.GetCatSingleton().transform.position = catStartLocation;
    }
}
