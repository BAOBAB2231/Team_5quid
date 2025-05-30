using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Anim_TriggerRightsideStep()
    {
        animator.SetTrigger("R_Side");
    }

    public void Anim_TriggerLeftsideStep()
    {
        animator.SetTrigger("L_Side");
    } 
    
    public void Anim_TriggerSquidCrash()
    {
        animator.SetTrigger("IsCrash");
    }

    public void Anim_SetJump(bool isJump)
    {
        animator.SetBool("IsJump", isJump);
    }

    public void Anim_SetCrouch(bool isCrouch)
    {
        animator.SetBool("IsCrouch", isCrouch);
    }

    public void Anim_SetSuddenDrop(bool isSuddenDrop)
    {
        animator.SetBool("IsDrop", isSuddenDrop);
    }
}
