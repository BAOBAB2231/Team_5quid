using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Rigidbody rb;
    protected Animator anim;
    protected Transform tf;
    [Header("이동 관련 스탯")]
    [SerializeField]private float runSpeed;
    public float RunSpeed{get{return runSpeed;}}
    [SerializeField] private float jumpForce;
    public float JumpForce{get{return jumpForce;}}  
    [SerializeField]
    private float sideStepDistance;
    
    void Awake()
    {
     rb = GetComponent<Rigidbody>();
     anim = GetComponent<Animator>();
     tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
