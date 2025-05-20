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
        inGame.Jump.performed += ctx => controller.ChangeState(controller.jumpState);
        inGame.Slide.performed += ctx => controller.Slide();
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
        /*onFoot.Enable();
        mouse.Enable();*/
        //menu.Enable();
    }
    private void OnDisable()
    {
        inGame.Disable(); 
        mouse.Disable();
        menu.Disable();
    }
    public Vector2 GetMoveInput()
    {
        return inGame.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseInput() => mouse.Look.ReadValue<Vector2>();

    public void StartState()
    {
        Debug.Log("Start Input");
        inGame.Enable();
        mouse.Enable();
        menu.Disable();
    }

    public void OverState()
    {
        Debug.Log("Over Input");
        inGame.Disable();
        mouse.Disable();
        menu.Enable();
    }
}
