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
        Vector3 run = rb.velocity;
       
        
        run.z = RunSpeed;
        
         rb.velocity = run;
    }
    void OnSideStep (InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
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
