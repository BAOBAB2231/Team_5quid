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

    private Coroutine jumpForceBuffRoutine;

    public void ApplyJumpForceBuff(float multiplier, float duration)
    {
        // 기존 버프가 있다면 중지
        if (jumpForceBuffRoutine != null)
            StopCoroutine(jumpForceBuffRoutine);

        jumpForceBuffRoutine = StartCoroutine(JumpForceBuffCoroutine(multiplier, duration));
    }

    /// <summary>
    /// 점프력 버프를 일정 시간 적용하고 원래대로 되돌립니다.
    /// </summary>
    private IEnumerator JumpForceBuffCoroutine(float multiplier, float duration)
    {
        float original = jumpForce;

        jumpForce *= multiplier;

        yield return new WaitForSeconds(duration);

        jumpForce = original;
        jumpForceBuffRoutine = null;
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