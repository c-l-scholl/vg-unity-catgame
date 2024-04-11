using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

// Change the movement style to accept the most recent keypress

public class CatMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public Slider staminaSlider;
    public Canvas staminaCanvas;

    private enum SprintState
    {
        WALKING,
        SPRINTING,
        EXHAUSTED,
        FROZEN

    }
    private SprintState currentSprintState = SprintState.WALKING;
    private readonly float MAX_STAMINA = 15f;
    private readonly float DRAIN_RATE = 3f;
    private readonly float RECHARGE_RATE = 4f;
    private float currentStamina;
    public float speed = 2f;
    private float sprintSpeed;
    private float tiredSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentStamina = MAX_STAMINA;
        sprintSpeed = 2f * speed;
        tiredSpeed = 0.5f * speed;
        SliderSetup();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        rigidBody.velocity = MovementHandling();
        SetStaminaSlider();
    }

    private void SliderSetup()
    {
        staminaSlider.maxValue = MAX_STAMINA;
        staminaSlider.value = currentStamina;
    }

    private void SetStaminaSlider()
    {
        staminaSlider.value = currentStamina;
        staminaCanvas.enabled = (currentStamina < MAX_STAMINA);
    }

    // should figure out a better way to disable movement
    public void disableMovement()
    {
        rigidBody.velocity = new Vector2(0,0);
        resetAnimateBool(null);
        // this.enabled = false;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.enabled = (false);
        currentSprintState = SprintState.FROZEN;
    }

    public void enableMovement()
    {
        rigidBody.constraints = RigidbodyConstraints2D.None;
        animator.enabled = (true);
        currentSprintState = SprintState.WALKING;
    }

    // Update is called once per frame
    

    private Vector2 MovementHandling()
    {
        Vector2 movement = Vector2.zero;
        float horizMove = Input.GetAxisRaw("Horizontal"); 
        float vertMove = Input.GetAxisRaw("Vertical"); 
        switch (currentSprintState)
        {
            case SprintState.WALKING:
                if (Input.GetKeyDown(KeyCode.LeftShift) && (horizMove != 0 || vertMove != 0))
                {
                    currentSprintState = SprintState.SPRINTING;

                }
                else
                {
                    horizMove *= speed;
                    vertMove *= speed;
                    if (currentStamina < MAX_STAMINA)
                    {
                        currentStamina += Time.deltaTime * RECHARGE_RATE;
                    }
                    else if (currentStamina >= MAX_STAMINA)
                    {
                        currentStamina = MAX_STAMINA;
                    }
                }
                break;
            case SprintState.SPRINTING:
                if (currentStamina <= 0.1f)
                {
                    currentSprintState = SprintState.EXHAUSTED;
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    horizMove *= sprintSpeed;
                    vertMove *= sprintSpeed;
                    currentStamina -= Time.deltaTime * DRAIN_RATE;
                }
                else
                {
                    currentSprintState = SprintState.WALKING;
                }
                break;
            case SprintState.EXHAUSTED:
                if (currentStamina < MAX_STAMINA)
                {
                    currentStamina += Time.deltaTime * RECHARGE_RATE;
                    horizMove *= tiredSpeed;
                    vertMove *= tiredSpeed;
                }
                else if (currentStamina >= MAX_STAMINA)
                {
                    currentStamina = MAX_STAMINA;
                    currentSprintState = SprintState.WALKING;
                }
                break;
            case SprintState.FROZEN:
                if (currentStamina < MAX_STAMINA)
                {
                    currentStamina += Time.deltaTime * RECHARGE_RATE;
                }
                else if (currentStamina >= MAX_STAMINA)
                {
                    currentStamina = MAX_STAMINA;
                    currentSprintState = SprintState.WALKING;
                }
                resetAnimateBool(null);
                animator.SetFloat("Speed", 0);
                return Vector2.zero;
        }
        if (horizMove != 0 || vertMove != 0)
        {
            movement = checkHorizontal(movement, horizMove);
            movement = checkVertical(movement, vertMove);
        }
        else
        {
            resetAnimateBool(null);
            animator.SetFloat("Speed", 0);
        } 
        SetStaminaSlider();
        return movement;
    }

    private Vector2 checkVertical(Vector2 movement, float dir)
    {
        if (dir > 0)
        {
            resetAnimateBool("Up");
        }
        else if (dir < 0)
        {
            resetAnimateBool("Down");
        }
        // movement.x = 0;
        movement.y = dir;

        return movement;
    }

    private Vector2 checkHorizontal(Vector2 movement, float dir)
    {
        if (dir > 0)
        {
            resetAnimateBool("Right");
        }
        else if (dir < 0)
        {
            resetAnimateBool("Left");
        }
        // movement.y = 0;
        movement.x = dir;

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



