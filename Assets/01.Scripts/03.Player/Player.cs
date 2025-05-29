using UnityEngine;

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
}