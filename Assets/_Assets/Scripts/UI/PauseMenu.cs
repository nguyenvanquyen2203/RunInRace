using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance;
    public static PauseMenu Instance { get { return instance; } }
    public MainMenu mainMenu;
    private bool isPause = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void PauseGameAct()
    {
        isPause = !isPause;
        if (isPause) PauseGame();
        else ResumeGame();
    }
    private void OnDisable()
    {
        isPause = false;
        Time.timeScale = 1;
    }
    private void OnEnable()
    {
        isPause = true;
        Time.timeScale = 0;
        AudioManager.Instance.PauseSFX();
    }
    private void ResumeGame() => mainMenu.HideMenu(transform);
    private void PauseGame() => mainMenu.ShowMenu(transform);
}
