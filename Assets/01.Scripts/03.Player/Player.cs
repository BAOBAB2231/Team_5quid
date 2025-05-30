using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour
{
    protected Rigidbody rb;
    protected Transform tf;
    protected MyAnimation anim;
    protected SFXPlayer sfx;
    private CapsuleCollider col;
    private Coroutine jumpForceBuffRoutine;
    [Header("이동 관련 스탯")]
    //전방 이동속도
    [SerializeField]
    protected float runSpeed;

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
        col = GetComponent<CapsuleCollider>();
    }

    public void ApplyJumpForceBuff(float multiplier, float duration)
    {
        if (jumpForceBuffRoutine != null)
            StopCoroutine(jumpForceBuffRoutine);
          
        jumpForceBuffRoutine =
                StartCoroutine(GameManager.Instance.Player.JumpForceBuffCoroutine(multiplier, duration));
       
    }



    /// <summary>
    /// 점프력 버프를 일정 시간 적용하고 원래대로 되돌립니다.
    /// </summary>
    public IEnumerator JumpForceBuffCoroutine(float multiplier, float duration)
    {
 
        float original = jumpForce;

        jumpForce *= multiplier;

        yield return new WaitForSeconds(3f);
       
        jumpForce = original;
        jumpForceBuffRoutine = null;
      
    }


    public IEnumerator Crash()
    {
        runSpeed = 0f;
        anim.Anim_TriggerSquidCrash();
        rb.useGravity = false;
        col.radius = 0.3f;
        col.height = 1.2f;
        yield return new WaitForSeconds(1f);

        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.back * 0.1f, ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        rb.velocity = Vector3.zero;
    }
}