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
        #region Initialize State
        idleState = new IdleState(this);
        runState = new RunState(this);
        jumpState = new JumpState(this);  
        slideState = new SlideState(this);
        flyState = new FlyState(this);
        dieState = new DieState(this);
        #endregion
        IntinializeState();
        GameManager.Instance.AddObserver(this);
        GameManager.Instance.ClearEvent.AddListener(IntinializeState);
        GetComponent<PlayerState>().deathEvt.AddListener(Death);
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
        Vector2 input = InputManager.Instance.GetMoveInput();
        rb.velocity = new Vector3(input.x * playerInfo.speed, rb.velocity.y, 0f);
        //Rotate Player
        transform.rotation = Quaternion.Euler(Vector3.up * (input.x * 45f));
    }
    private bool IsGround() => Physics.Raycast(transform.position + 0.75f * Vector3.up, Vector3.down, 0.8f, groundLayer) && rb.velocity.y <= 0f;
    public bool IsGrounded() => isGrounded;
    public void ChangeAnimState(string newState, float crossTime = 0f)
    {
        //if (currentAnimState == newState) return; 
        currentAnimState = newState;
        anim.CrossFade(currentAnimState, crossTime);
    }
    public void ChangeJumpState()
    {
        if (state == slideState || isGrounded) ChangeState(jumpState);
    }
    public void Jump() => rb.AddForce(Vector3.up * playerInfo.jumpForce, ForceMode.Impulse);
    public void OnTriggerEventAct(OnTriggerEvent evt)
    {
        state.TriggerEvent(evt);
    }
    public void Slide()
    {
        if (isGrounded) ChangeState(slideState);
    }
    private void IntinializeState() {
        state = idleState;
        state.EnterState();
    }

    /*public void StartState()
    {
        rb.useGravity = true;
        state = runState;
        state.EnterState();
    }*/
    public void StartState()
    {
        //rb.useGravity = true;
        ChangeState(runState);
    }
    public void ResetPosition() => transform.position = originalPos;

    public void OverState()
    {
        
    }
    public void Death() => ChangeState(dieState);
}