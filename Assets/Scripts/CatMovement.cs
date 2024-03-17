using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

// Change the movement style to accept the most recent keypress

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    public float speed = 1.5f;
    private float sprintSpeed;
    private float tiredSpeed;

    Rigidbody2D rigidBody;
    // UnityEngine.KeyCode lastKey;


    // Start is called before the first frame update
    void Start()
    {
        sprintSpeed = speed * 1.5f;
        tiredSpeed = speed * 0.67f;

        rigidBody = GetComponent<Rigidbody2D>();
        // lastKey = KeyCode.None;
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
        

        // UnityEngine.KeyCode key = KeyCode.None;

        
        // if (horizMove != 0 && vertMove != 0) {
        //     if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
        //         vertMove = 0;
        //     } else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
        //         horizMove = 0;
        //     }
        // }

        // checkVertical(movement, key);
        // checkHorizontal(movement, key);
        // movement.x = horizMove;
        // movement.y = vertMove;

        // bool keyCheck = lastKey != key;

        // if (horizMove != 0 && vertMove != 0) {
    
        // }
        if (horizMove != 0 || vertMove != 0) {
            if (horizMove != 0)
            {
                if (horizMove > 0) {
                    resetAnimateBool("Right");
                } else {
                    resetAnimateBool("Left");
                }
                movement.y = 0;
                movement.x = horizMove;
                // movement = checkVertical(movement, vertMove);
            }
            if (vertMove != 0)
            {
                if (vertMove > 0) {
                    resetAnimateBool("Up");
                } else {
                    resetAnimateBool("Down");
                }
                movement.x = 0;
                movement.y = vertMove;
                // movement = checkHorizontal(movement, horizMove);
            }
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
                movement.x = 0;
                movement.y = dir;
                // movement = checkHorizontal(movement, horizMove);
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
                movement.y = 0;
                movement.x = dir;
                // movement = checkVertical(movement, vertMove);
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



