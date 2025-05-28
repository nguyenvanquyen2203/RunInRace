using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GameStateSubject
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public MapManager mapManager;
    public ParticleEffects pSE;
    [SerializeField] private float mapSpeed;
    [SerializeField] private float currentMapSpeed;
    [HideInInspector] public UnityEvent InitializeGameEvent;
    [HideInInspector] public UnityEvent ClearEvent;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI hdText;
    public float timeSpeedUp;
    private int coinMap;
    private float currentTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentMapSpeed = mapSpeed;
        currentTime = 0f;
        SetMapSpeed(currentMapSpeed);
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
        CoinData.Instance.PlusCoin(coinMap);
    }
    public void InitializeMap()
    {
        mapManager.SpawnDefaultMap(Vector3.zero);
        mapManager.SpawnDefaultMap(Vector3.forward * 20);
        mapManager.SpawnDefaultMap(Vector3.forward * 40);
        //mapManager.SpawnDefaultMap(Vector3.forward * 30);
    }
    public void GetCoin()
    {
        coinMap++;
        coinText.text = coinMap.ToString();
    }
    public void StartGame()
    {
        StartGameAct();
        CloseHD();
    }
    public void ResetMap()
    {
        currentMapSpeed = mapSpeed;
        GameModeManager.Instance.ChangeGameMode();
        AudioManager.Instance.PlayMusic("GameMusic");
        InitializeGameEvent?.Invoke();
        mapManager.StopRun();
        OpenHD();
        //StartGame();
    }
    private void OpenHD()
    {
        hdText.gameObject.SetActive(true);
    }
    private void CloseHD()
    {
        hdText.gameObject.SetActive(false);
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
            currentMapSpeed++;
            currentTime = 0;
            SetMapSpeed(currentMapSpeed);
        }
    }
    public void ActiveExplostion(Vector3 pos)
    {
        pSE.ActiveEffect(pos, currentMapSpeed);
    }
    public float GetSpeed() => currentMapSpeed;
}
