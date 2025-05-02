using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GameStateSubject
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public _MapManager mapManager;
    [SerializeField] private float mapSpeed;
    [SerializeField] public UnityEvent InitializeGameEvent;
    public TextMeshProUGUI coinText;
    public GameObject menuUI;
    private int coinMap;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetMapSpeed(mapSpeed);
        InitializeGameEvent.AddListener(InitializeMap);
        PlayerState.Instance.deathEvt.AddListener(DeathAction);
        InitializeGameEvent?.Invoke();
        mapManager.StopRun();
    }
    private void SetMapSpeed(float _speed)
    {
        mapManager.SetMapSpeed(_speed);
    }
    public void DeathAction()
    {
        mapManager.StopRun();
        CoinData.Instance.PlusCoin(coinMap);
    }
    public void InitializeMap()
    {
        mapManager.SpawnMap(Vector3.zero);
        mapManager.SpawnMap(Vector3.forward * 10);
        mapManager.SpawnMap(Vector3.forward * 20);
    }
    public void GetCoin()
    {
        coinMap++;
        coinText.text = coinMap.ToString();
    }
    public void StartGame()
    {
        StartGameAct();
    }
}
