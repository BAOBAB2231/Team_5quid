using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour
{
    protected Rigidbody rb;
    protected Transform tf;
    protected MyAnimation anim;
    protected SFXPlayer sfx;

    [Header("이동 관련 스탯")]
    //전방 이동속도
    [SerializeField] protected float runSpeed;
   [SerializeField] protected float jumpForce;
    [SerializeField] protected float sideStepDistance;
    [SerializeField] protected float stepDuration;
    [SerializeField] protected float maxDistance;
    public LayerMask groundLayerMask;


    void Start()
    {
        anim = GetComponent<MyAnimation>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        sfx = GetComponentInChildren<SFXPlayer>();
    }

    // 점프력 접근용 메서드
    public float GetJumpForce()
    {
        return jumpForce;
    }

    public void SetJumpForce(float value)
    {
        jumpForce = value;
    }

    public void SquidCrash()
    {
        StartCoroutine(Crash());

    }
    
    IEnumerator Crash()
    {
        anim.Anim_TriggerSquidCrash();
        rb.useGravity = false;
        
        yield return new WaitForSeconds(2f);
       
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None; 

    }
}