using System;
using UnityEngine;
public class PlayerController : MonoBehaviour, IGameStateObserver
{
    public p_State state;
    //public Transform playerBody;
    [HideInInspector] public Rigidbody rb;
    private Animator anim;
    private string currentAnimState;
    public LayerMask groundLayer;
    public pPlayer playerInfo;
    private bool isGrounded;
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public SlideState slideState;
    public FlyState flyState;
    public FallState fallState;
    public DieState dieState;
    private Vector3 originalPos;
    private CapsuleCollider _collider;
    private ColliderStatus originalCollider;
    private Vector2 input;
    public enum OnTriggerEvent
    {
        EndSlide
    }
    public enum OnActionEvent
    {
        Slide,
        Jump,
        EndFlying
    }
    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        originalPos = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        #region Initialize State
        idleState = new IdleState(this);
        runState = new RunState(this);
        jumpState = new JumpState(this);  
        slideState = new SlideState(this);
        flyState = new FlyState(this);
        fallState = new FallState(this);
        dieState = new DieState(this);
        #endregion
        IntinializeState();
        GameManager.Instance.AddObserver(this);
        GameManager.Instance.ClearEvent.AddListener(IntinializeState);
        GetComponent<PlayerState>().deathEvt.AddListener(Death);
        SaveColliderInfo();
    }

    private void SaveColliderInfo()
    {
        originalCollider = new ColliderStatus(_collider.center, _collider.radius, _collider.height);
    }
    public void ResetCollider()
    {
        transform.position = new Vector3(transform.position.x, 0f, 0f);
        _collider.center = originalCollider.centerPos;
        _collider.radius = originalCollider.radius;
        _collider.height = originalCollider.height;
    }

    public void ChangeState(p_State newState)
    {
        if (state != null) state.ExitState();
        if (state == newState) return;
        state = newState;
        state.EnterState();
    }
    void Update()
    {
        isGrounded = IsGround();
        state?.Update();
    }
    private void FixedUpdate()
    {
        state?.FixedUpdate();
    }
    public void Move()
    {
        input = InputManager.Instance.GetMoveInput();
        rb.velocity = new Vector3(input.x * playerInfo.speed, rb.velocity.y, 0f);
        //Rotate Player
        //transform.rotation = Quaternion.Euler(Vector3.up * (input.x * 45f));
    }
    private bool IsGround() => Physics.Raycast(transform.position + 0.75f * Vector3.up, Vector3.down, 0.8f, groundLayer) && rb.velocity.y <= 0f;
    public void RotatePlayer() => transform.rotation = Quaternion.Euler(Vector3.up * (input.x * 45f));
    public void FlyRotate(bool isFly = true)
    {
        if (!isFly)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            return;
        }
        Vector3 rotation = Vector3.zero;
        if (input.x > 0f) rotation = new Vector3(0f, 0f, -45f);
        if (input.x < 0f) rotation = new Vector3(0f, 0f, 45f);
        if (input.x == 0f) rotation = new Vector3(0f, 0f, 0f);
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, .03f);
    }
    public bool IsGrounded() => isGrounded;
    public void ChangeAnimState(string newState, float crossTime = 0f)
    {
        //if (currentAnimState == newState) return; 
        currentAnimState = newState;
        anim.CrossFade(currentAnimState, crossTime);
    }
    public void Jump() => rb.AddForce(Vector3.up * playerInfo.jumpForce, ForceMode.Impulse);
    public void OnTriggerEventAct(OnTriggerEvent evt)
    {
        if (state == dieState) return;
        state.TriggerEvent(evt);
    } 
    public void OnActionEventAct(OnActionEvent evt) => state.ActionEvent(evt);
    private void IntinializeState() => ChangeState(idleState);
    public void StartState() => ChangeState(runState);
    public void ResetPosition() => transform.position = originalPos;

    public void OverState()
    {
        
    }
    public void Death() => ChangeState(dieState);
    public void ResetForce() => rb.velocity = Vector3.zero;
}
public class ColliderStatus
{
    public Vector3 centerPos;
    public float radius;
    public float height;
    public ColliderStatus(Vector3 _centerPos, float _radius, float _height)
    {
        centerPos = _centerPos;
        radius = _radius;
        height = _height;
    }
}