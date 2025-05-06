using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour, IGameStateObserver
{
    public GameObject overMenu;
    public TextMeshProUGUI coinTxt;
    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void HideMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    private void Start()
    {
        GameManager.Instance.AddObserver(this);
    }
    public void ShowOverMenu()
    {
        ShowMenu(overMenu);
    }

    public void StartState()
    {
        
    }

    public void OverState()
    {
        ShowMenu(overMenu);
        coinTxt.text = GameManager.Instance.coinText.text;
    }
}
