using System;
using System.Collections;
using System.Collections.Generic;
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
        //rigidBody.velocity = CalculateMovement();
        Movement();
    }

    private Vector2 CalculateMovement()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            resetAnimateBool("Right");
            movement.x = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            resetAnimateBool("Left");
            movement.x = -speed;
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
            animator.SetFloat("Speed", 0);
        }

        return movement;
    }

    private void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.transform.position + tempVect);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            resetAnimateBool("Right");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            resetAnimateBool("Left");
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            resetAnimateBool("Up");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            resetAnimateBool("Down");
        }
        else
        {
            resetAnimateBool(null);
        }
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



