using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GameStateSubject
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public _MapManager mapManager;
    [SerializeField] private float mapSpeed;
    [HideInInspector] public UnityEvent InitializeGameEvent;
    [HideInInspector] public UnityEvent ClearEvent;
    public TextMeshProUGUI coinText;
    public float timeSpeedUp;
    private int coinMap;
    private float currentTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentTime = 0f;
        SetMapSpeed(mapSpeed);
        InitializeGameEvent.AddListener(InitializeMap);
        PlayerState.Instance.deathEvt.AddListener(DeathAction);
    }
    private void SetMapSpeed(float _speed)
    {
        mapManager.SetMapSpeed(_speed);
    }
    public void DeathAction()
    {
        OverGameAct();
        //mapManager.StopRun();
        //DeathEvent?.Invoke();
        CoinData.Instance.PlusCoin(coinMap);
    }
    public void InitializeMap()
    {
        mapManager.SpawnMap(Vector3.zero);
        mapManager.SpawnMap(Vector3.forward * 10);
        mapManager.SpawnMap(Vector3.forward * 20);
        mapManager.SpawnMap(Vector3.forward * 30);
    }
    public void GetCoin()
    {
        coinMap++;
        coinText.text = coinMap.ToString();
    }
    public void StartGame()
    {
        Debug.Log("StartGame");
        StartGameAct();
    }
    public void ResetMap()
    {
        AudioManager.Instance.PlayMusic("GameMusic");
        InitializeGameEvent?.Invoke();
        mapManager.StopRun();
    }
    public void ClearMap()
    {
        mapManager.ClearObservers();
        ClearEvent?.Invoke();
        coinMap = 0;
        coinText.text = coinMap.ToString();
    }
    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime >= timeSpeedUp)
        {
            mapSpeed++;
            currentTime = 0;
            SetMapSpeed(mapSpeed);
        }
    }
}
