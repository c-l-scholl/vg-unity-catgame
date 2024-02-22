using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

// Change the movement style to accept the most recent keypress

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    public float speed = 1.5f;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector2 movement;
        movement.y = 0;
        movement.x = 0;
        float horizMove = Input.GetAxisRaw("Horizontal") * speed;
        
        if (horizMove > 0)
        {
            resetAnimateBool("Right");
            movement.x = horizMove;
            if (Input.GetKey(KeyCode.UpArrow)) {
                movement.y = speed;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                movement.y = -speed;
            }
        }
        else if (horizMove < 0)
        {
            resetAnimateBool("Left");
            movement.x = horizMove;
            if (Input.GetKey(KeyCode.UpArrow)) {
                movement.y = speed;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                movement.y = -speed;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            resetAnimateBool("Up");
            movement.y = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            resetAnimateBool("Down");
            movement.y = -speed;
        }
        else
        {
            resetAnimateBool(null);
            movement.x = 0;
            movement.y = 0;
            animator.SetFloat("Speed", 0);
        }

        rigidbody.velocity = movement;
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



