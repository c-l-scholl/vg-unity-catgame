using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatCarCollision : MonoBehaviour
{
    public UnityEvent hitEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            // Collision detected between the car and the player
            // You can perform any actions here, such as damaging the player, playing a sound, etc.
            hitEvent.Invoke();
        }
    }
}
