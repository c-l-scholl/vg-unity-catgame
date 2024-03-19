using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

// Change the movement style to accept the most recent keypress

public class CatMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 10.5f;
    private float sprintSpeed;
    private float tiredSpeed;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        sprintSpeed = speed * 1.5f;
        tiredSpeed = speed * 0.67f;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector2 movement;
        movement.y = 0;
        movement.x = 0;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        float vertMove = Input.GetAxisRaw("Vertical") * speed;

        if (horizMove != 0 || vertMove != 0) {
            movement = checkHorizontal(movement, horizMove);
            movement = checkVertical(movement, vertMove);
        }
        else
        {
            resetAnimateBool(null);
            animator.SetFloat("Speed", 0);
        }

        rigidBody.velocity = movement;
        
    }

    private Vector2 checkVertical(Vector2 movement, float dir) {
        if (dir != 0)
            {
                if (dir > 0) {
                    resetAnimateBool("Up");
                } else {
                    resetAnimateBool("Down");
                }
                // movement.x = 0;
                movement.y = dir;
            }

        return movement;
    }

    private Vector2 checkHorizontal(Vector2 movement, float dir) {
        if (dir != 0)
            {
                if (dir > 0) {
                    resetAnimateBool("Right");
                } else {
                    resetAnimateBool("Left");
                }
                // movement.y = 0;
                movement.x = dir;
            }

        return movement;
    }

    // Sets all animation booleans to false except for the exception
    private void resetAnimateBool(string exception)
    {
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);

        if (exception != null)
        {
            animator.SetBool(exception, true);
        }
    }
}



