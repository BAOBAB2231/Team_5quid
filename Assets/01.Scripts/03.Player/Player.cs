using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour
{
    protected Rigidbody rb;
    protected Transform tf;
    protected MyAnimation anim;
    protected SFXPlayer sfx;
    private CapsuleCollider col;
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
        col = GetComponent<CapsuleCollider>();
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
        rb.AddForce(Vector3.back*0.1f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        
      //색깔도 변하게 
    }
    
    //플레이어 프리팹을 
    //씬 시작하때 인스티에이트 해주
}