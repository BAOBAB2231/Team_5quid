using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    
    

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
                if (tf.position.x <= -maxDistance)
                {
                    return;
                }

                tf.position -= new Vector3(sideStepDistance, 0, 0);
            }
            else if (context.control.name == "rightArrow")
            {
                if (tf.position.x >= maxDistance)
                {
                    return;
                }

                tf.position += new Vector3(sideStepDistance, 0, 0);
            }
        }
       
    }

    


   public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            
        }
    }

  
  public  void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Vector3 scale = tf.localScale;
            scale.y/= 2;
            tf.localScale = scale;

        }

        if (context.phase == InputActionPhase.Canceled)
        {
            Vector3 scale = tf.localScale;
            scale.y*= 2;
            tf.localScale = scale;
        }
    }

    


  public  void OnSuddenDrop(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {   Vector3 currentPosition = tf.position;
            currentPosition.y = playerPivotY;
            tf.position = currentPosition;

        }
    }
  
  
}