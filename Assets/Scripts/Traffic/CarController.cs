using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class CarController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 8f; // Speed of the car

    [SerializeField]
    private float moveDuration = 300f; // Duration for which the car should move (in seconds)
    private bool goingRight;
    // [SerializeField]
    // private float moveDistance = 100f; // Distance for which the car should move (in units)
    private float moveTimer; // Timer to keep track of how long the car has been moving

    // private Vector3 initialPosition; // Initial position of the car
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        goingRight = gameObject.GetComponentInParent<CarSpawner>().goesRight;
        if (!goingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        // initialPosition = transform.position; // Store initial position of the car
        Move();
    }

    private void Move()
    {
        if (goingRight) 
        {
            rb.velocity = new Vector2(moveSpeed, 0f); // Start moving the car to the right
        }
        else 
        {
            rb.velocity = new Vector2(-moveSpeed, 0f); // Start moving the car to the left
        }
        // rb.velocity = new Vector2(moveSpeed, 0f); // Start moving the car to the right
    }

    private void FixedUpdate()
    {
        // Increment the move timer every fixed update
        moveTimer += Time.fixedDeltaTime;

        // Check if the move duration has elapsed
        if (moveTimer >= moveDuration)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Move();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (
            other.gameObject.CompareTag("VertBorder") ||
            other.gameObject.CompareTag("SideBorder") ||
            other.gameObject.CompareTag("RightBorder") ||
            other.gameObject.CompareTag("Border")
        )
        {
            Destroy (gameObject);
        }
    }
}
