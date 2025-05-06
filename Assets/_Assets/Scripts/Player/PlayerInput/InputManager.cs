using UnityEngine;

public class InputManager : MonoBehaviour, IGameStateObserver
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerInput.MouseActions mouse;
    private PlayerInput.MenuActionActions menu;
    private PlayerController controller;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        instance = this;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        mouse = playerInput.Mouse;
        menu = playerInput.MenuAction;
        onFoot.Jump.performed += ctx => controller.ChangeState(controller.jumpState);
        onFoot.Slide.performed += ctx => controller.Slide();
        menu.StartGame.performed += ctx => GameManager.Instance.StartGame();
    }
    void Start()
    {
        GameManager.Instance.AddObserver(this);
        onFoot.Disable();
        mouse.Disable();
    }
    private void OnEnable()
    {
        /*onFoot.Enable();
        mouse.Enable();*/
        menu.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable(); 
        mouse.Disable();
    }
    public Vector2 GetMoveInput()
    {
        return onFoot.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseInput() => mouse.Look.ReadValue<Vector2>();

    public void StartState()
    {
        Debug.Log("Start Input");
        onFoot.Enable();
        mouse.Enable();
        menu.Disable();
    }

    public void OverState()
    {
        Debug.Log("Over Input");
        onFoot.Disable();
        mouse.Disable();
        menu.Enable();
    }
}
