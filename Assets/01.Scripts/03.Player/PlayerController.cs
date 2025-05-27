using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    { //부하가 많이 걸리므로 스타트로 
        /*if (rb == null)
        {
            return;
        }*/

        //Vector3 run = rb.velocity;
        //run.z = RunSpeed;

        //rb.velocity = run;
        
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, Time.deltaTime * runSpeed);
        
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * runSpeed);
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

    IEnumerator LerpSideSetp()
    {

        yield return new While()
        {
           
        };

    }



    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started&&IsGrounded())
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    bool IsGrounded()
    {  
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.up * 0.1f), Vector3.down*2f),
            new Ray(transform.position + (-transform.forward * 0.5f) + (transform.up * 0.1f), Vector3.down*2f),
            new Ray(transform.position + (transform.right * 0.5f) + (transform.up * 0.1f), Vector3.down*2f),
            new Ray(transform.position + (-transform.right * 0.5f) + (transform.up * 0.1f), Vector3.down*2f)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;

    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.up * 0.05f), Vector3.down*2f),
            new Ray(transform.position + (-transform.forward * 0.5f) + (transform.up * 0.05f), Vector3.down*2f),
            new Ray(transform.position + (transform.right * 0.5f) + (transform.up * 0.05f), Vector3.down*2f),
            new Ray(transform.position + (-transform.right * 0.5f) + (transform.up * 0.05f), Vector3.down*2f)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            Gizmos.DrawLine(rays[i].origin, rays[i].origin + rays[i].direction * 0.1f);
        }
    }
    bool isCrouching=false;
    public  void OnCrouch(InputAction.CallbackContext context)
    {
        
        if (IsGrounded())
        {
            if (context.phase == InputActionPhase.Started&&!isCrouching)
            {
                Vector3 scale = tf.localScale;
                scale.y /= 2;
                tf.localScale = scale;
                isCrouching = true;
            }

            if (context.phase == InputActionPhase.Canceled&&isCrouching)
            {
                Vector3 scale = tf.localScale;
                scale.y *= 2;
                tf.localScale = scale;
                isCrouching = true;
            }
        }
    }

    


  public  void OnSuddenDrop(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started&&!IsGrounded())
        {   Vector3 currentPosition = tf.position;
           
            /*currentPosition.y = playerPivotY;
            tf.position = currentPosition;*/
             StartCoroutine(MassUp());
        }
    }

    IEnumerator MassUp()
    {
        rb.velocity = Vector3.down*10;
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }

}