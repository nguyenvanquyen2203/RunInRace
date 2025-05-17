using TMPro;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour, IGameStateObserver
{
    public GameObject overMenu;
    public TextMeshProUGUI coinTxt;
    private void Start()
    {
        GameManager.Instance.AddObserver(this);
    }
    public void ShowOverMenu()
    {
        overMenu.gameObject.SetActive(true);
    }

    public void StartState()
    {
        
    }

    public void OverState()
    {
        ShowOverMenu();
        coinTxt.text = GameManager.Instance.coinText.text;
    }
    public void ShowMenu(Transform menu)
    {
        menu.localScale = Vector3.zero;
        menu.gameObject.SetActive(true);
        menu.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetUpdate(UpdateType.Normal, true);
    }
    public void HideMenu(Transform menu)
    {
        menu.localScale = Vector3.one;
        menu.DOScale(Vector3.zero, 0.5f).SetUpdate(UpdateType.Normal, true).SetEase(Ease.OutQuad).OnComplete(() => { menu.gameObject.SetActive(false); });
    }
}
