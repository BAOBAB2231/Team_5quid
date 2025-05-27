using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
   protected Rigidbody rb;
   protected Transform tf;
    protected Animator anim;
   
    [Header("이동 관련 스탯")]
    [SerializeField]protected float runSpeed;
    public float RunSpeed{get{return runSpeed;}}
    [SerializeField] protected float jumpForce;
    public float JumpForce{get{return jumpForce;}}  
    [SerializeField] protected float sideStepDistance;
    [SerializeField]protected float maxDistance;
    [SerializeField]protected float playerPivotY;
    public LayerMask groundLayerMask;
    void Start()
    {
     anim = GetComponent<Animator>();
     tf = GetComponent<Transform>();
     rb = GetComponent<Rigidbody>();
    
    }

 
    void Update()
    {
        
    }
    
    
}
