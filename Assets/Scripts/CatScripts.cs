using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // animator.SetBool("Right", true);
            resetAnimateBool("Right");
            movement.x = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // animator.SetBool("Left", true);
            resetAnimateBool("Left");
            movement.x = -speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // animator.SetBool("Up", true);
            resetAnimateBool("Up");
            movement.y = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // animator.SetBool("Down", true);
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



