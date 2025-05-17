using UnityEngine;

public class PlayerController : MonoBehaviour, IGameStateObserver
{
    public p_State state;
    public Transform playerBody;
    private Rigidbody rb;
    private Animator anim;
    private string currentAnimState;
    public LayerMask groundLayer;
    public pPlayer playerInfo;
    private bool isGrounded;
    public RunState runState;
    public JumpState jumpState;
    public SlideState slideState;
    public DieState dieState;
    private Vector3 originalPos;
    public enum OnTriggerEvent
    {
        EndSlide
    }
    private void Awake()
    {
        originalPos = transform.position;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        IntinializeState();
        runState = new RunState(this);
        jumpState = new JumpState(this);  
        slideState = new SlideState(this);
        dieState = new DieState(this);
        GameManager.Instance.AddObserver(this);
        GameManager.Instance.ClearEvent.AddListener(IntinializeState);
        GetComponent<PlayerState>().deathEvt.AddListener(Death);
    }
    public void ChangeState(p_State newState)
    {
        if (state != null) state.ExitState();
        state = newState;
        state.EnterState();
    }
    void Update()
    {
        isGrounded = IsGround();
        Move();
        state?.Update();
    }
    private void FixedUpdate()
    {
        state?.FixedUpdate();
    }
    public void Move()
    {
        Vector2 input = InputManager.Instance.GetMoveInput();
        rb.velocity = new Vector3(input.x * playerInfo.speed, rb.velocity.y, 0f);
        RotatePlayer(input.x);
    }
    private void RotatePlayer(float xMove)
    {
        transform.rotation = Quaternion.Euler(Vector3.up * (xMove * 45f));
    }
    private bool IsGround()
    {
        return Physics.Raycast(transform.position + 0.75f * Vector3.up, Vector3.down, 0.8f, groundLayer) && rb.velocity.y <= 0f;
    }
    public bool IsGrounded() => isGrounded;
    public void ChangeAnimState(string newState, float crossTime)
    {
        //if (currentAnimState == newState) return; 
        currentAnimState = newState;
        anim.CrossFade(currentAnimState, crossTime);
    }
    public void AddForce(Vector3 forceDir, float forceValue)
    {
        rb.AddForce(forceDir * forceValue, ForceMode.Impulse);
    }
    public void Jump()
    {
        if (isGrounded) rb.AddForce(Vector3.up * playerInfo.jumpForce, ForceMode.Impulse);
    }
    public Vector3 GetVelocity() => rb.velocity;
    public void OnTriggerEventAct(OnTriggerEvent evt)
    {
        state.TriggerEvent(evt);
    }
    public void Slide()
    {
        if (isGrounded) ChangeState(slideState);
    }
    private void IntinializeState() {
        gameObject.layer = LayerMask.NameToLayer("Player");
        currentAnimState = "Idle";
        transform.position = originalPos;
        ChangeAnimState(currentAnimState, 0f);
        rb.useGravity = false;
    }

    public void StartState()
    {
        rb.useGravity = true;
        ChangeState(runState);
    }

    public void OverState()
    {
        
    }
    public void Death()
    {
        ChangeState(dieState);
        gameObject.layer = LayerMask.NameToLayer("Invisible");
    }
}
