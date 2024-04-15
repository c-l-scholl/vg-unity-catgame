using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class CarController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float power = 5;

    [SerializeField]
    private float torque = 0.5f;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movementInput)
    {
        this.movementVector = movementInput;
    }

    private void FixedUpdate()
    {
        // Calculate forward force based on movement input
        Vector2 forwardForce = transform.up * movementVector.y * power;
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce (forwardForce);
        }

        // Calculate torque based on steering input
        float steeringTorque =
            -movementVector.x * torque * rb.velocity.magnitude;
        rb.AddTorque (steeringTorque);
    }
}
