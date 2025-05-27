using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected Rigidbody rb;
    protected Animator anim;
    protected Transform tf;
    [Header("이동 관련 스탯")]
    public float speed;
    public float jumpForce;
    
    
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
