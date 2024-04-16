using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntroPanelScript : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panel = GetComponent<GameObject>();
        if (Input.GetKey(KeyCode.P))
        {
            panel.SetActive(false);
        }
    }
}
