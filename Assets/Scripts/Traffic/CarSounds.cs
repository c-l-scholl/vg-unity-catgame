using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarSounds : MonoBehaviour
{
    private AudioSource carHonkSound;

    void Start() {
        carHonkSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("MainCamera")) {
            carHonkSound.Play();
        }
    }
}
