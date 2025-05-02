using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerBody;
    private Rigidbody rb;
    [HideInInspector] public UnityEvent jumpEvent = null;
    [HideInInspector] public UnityEvent slideEvent = null;
    public LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float deathForce;
    private bool isGrounded;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        PlayerState.Instance.deathEvt.AddListener(DeathAction);
        rb.constraints = RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationY |
                         RigidbodyConstraints.FreezeRotationZ;

    }

    // Update is called once per frame
    void Update()
    {   
        isGrounded = IsGround();
        Move();
    }

    public void Move()
    {
        Vector2 input = InputManager.Instance.GetMoveInput();
        rb.velocity = new Vector3(input.x * speed, rb.velocity.y, 0f);
        RotatePlayer(input.x);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpEvent?.Invoke();
        }
    }
    private void RotatePlayer(float xMove)
    {
        transform.rotation = Quaternion.Euler(Vector3.up * (xMove * 45f));
    }
    public void Slide()
    {
        if (isGrounded) slideEvent?.Invoke();
    }
    private bool IsGround()
    {
        return Physics.Raycast(transform.position + 0.75f * Vector3.up, Vector3.down, 0.8f, groundLayer) && rb.velocity.y <= 0f;
    }
    private void DeathAction()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationY |
                         RigidbodyConstraints.FreezeRotationZ;
        rb.AddForce(Vector3.back * deathForce, ForceMode.Impulse);
    }
}
