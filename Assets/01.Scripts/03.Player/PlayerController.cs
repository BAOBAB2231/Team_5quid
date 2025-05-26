using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    void Awake()
    {
    }


    void Update()
    {
    }

    void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        if (rb == null)
        {
            return;
        }

        Vector3 run = rb.velocity;


        run.z = RunSpeed;

        rb.velocity = run;
    }

    public void OnSideStep(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (context.control.name == "leftArrow")
            {
                if (tf.position.x == -maxDistance)
                {
                    return;
                }

                tf.position -= new Vector3(sideStepDistance, 0, 0);
            }
            else if (context.control.name == "rightArrow")
            {
                if (tf.position.x == maxDistance)
                {
                    return;
                }

                tf.position += new Vector3(sideStepDistance, 0, 0);
            }
        }
        else 
        {
            return;
        }
    }

    void SideStep()
    {
    }


    void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
        }
    }

    void Jump()
    {
    }

    void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
        }
    }

    void Crouch()
    {
    }
}