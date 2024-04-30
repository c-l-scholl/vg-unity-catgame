using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
    public void destroyItem() {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
