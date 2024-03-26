using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSprinting : MonoBehaviour
{
    private float sprintSpeed;
    private float tiredSpeed;
    private enum SprintState
    {
        WALKING,
        SPRINTING,
        EXHAUSTED
    }
    private SprintState currentSprintState = SprintState.WALKING;
    public float maxStamina = 100f;
    private float currentStamina = 100f;
    private float drainRate = 1f;
    private float rechargeRate = 1f;
    private bool isRunning = false;

    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        sprintSpeed = 1.5f;
        tiredSpeed = 0.67f;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     switch (currentSprintState)
    //     {
    //         case SprintState.WALKING:
    //             if (Input.GetKeyDown(KeyCode.LeftShift))
    //             {
    //                 currentSprintState = SprintState.SPRINTING;
    //             }
    //             break;
    //         case SprintState.SPRINTING:
    //             if (currentStamina <= 0.1f)
    //             {
    //                 currentSprintState = SprintState.EXHAUSTED;
    //             }
    //             else if (Input.GetKey(KeyCode.LeftShift) && !isRunning)
    //             {
    //                 rigidBody.velocity.x *= sprintSpeed;
    //                 rigidBody.velocity.x *= sprintSpeed;
    //                 currentStamina -= Time.deltaTime * drainRate;
    //             }
    //             else
    //             {
    //                 isRunning = false;
    //                 currentSprintState = SprintState.EXHAUSTED;
    //             }
    //             break;
    //         case SprintState.EXHAUSTED:
    //             while (currentStamina < maxStamina)
    //             {
    //                 currentStamina += Time.deltaTime * rechargeRate;
    //             }
    //             if (currentStamina > maxStamina)
    //             {
    //                 currentStamina = maxStamina;
    //             }
    //             currentSprintState = SprintState.WALKING;
    //             break;

    //     }


    // }
}
