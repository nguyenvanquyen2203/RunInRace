using UnityEngine;

public class InputManager : MonoBehaviour, IGameStateObserver
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }
    private PlayerInput playerInput;
    private PlayerInput.InGameActions inGame;
    private PlayerInput.MouseActions mouse;
    private PlayerInput.MenuActionActions menu;
    private PlayerController controller;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        instance = this;
        playerInput = new PlayerInput();
        inGame = playerInput.InGame;
        mouse = playerInput.Mouse;
        menu = playerInput.MenuAction;
        inGame.Jump.performed += ctx => controller.OnActionEventAct(PlayerController.OnActionEvent.Jump);
        inGame.Slide.performed += ctx => controller.OnActionEventAct(PlayerController.OnActionEvent.Slide);
        menu.StartGame.performed += ctx => GameManager.Instance.StartGame();    
    }
    void Start()
    {
        inGame.PauseGame.performed += ctx => PauseMenu.Instance.PauseGameAct();
        GameManager.Instance.AddObserver(this);
        GameManager.Instance.InitializeGameEvent.AddListener(OverState);
        inGame.Disable();
        mouse.Disable();
        menu.Disable();
    }
    private void OnEnable()
    {
        OverState();
    }
    public Vector2 GetMoveInput()
    {
        return inGame.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseInput() => mouse.Look.ReadValue<Vector2>();

    public void StartState()
    {
        inGame.Enable();
        mouse.Enable();
        menu.Disable();
    }

    public void OverState()
    {
        inGame.Disable();
        mouse.Disable();
        menu.Disable();
    }
    public void ReadyGame()
    {
        inGame.Disable();
        mouse.Disable();
        menu.Enable();
    }
}
