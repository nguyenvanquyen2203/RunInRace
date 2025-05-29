using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance {  get { return instance; } }
    private List<CoinItem> coins = new List<CoinItem>();
    private List<Transform> coinsMagnet = new List<Transform>();
    public float magnetSpeed;
    private Quaternion rotation;
    public float rotationSpeed = 60f;
    private float magnetActive;
    private Transform player;
    public MagnetZone groundMagnet;
    public MagnetZone airMagnet;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rotation = Quaternion.identity;
        player = PlayerState.Instance.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        #region Rotate Coin
        rotation *= Quaternion.Euler(Vector3.up * Time.fixedDeltaTime * rotationSpeed);
        foreach (CoinItem coin in coins)
        {
            coin.transform.rotation = rotation;
        }
        #endregion

        #region Magnet Coin
        for (int i = 0; i < coinsMagnet.Count; i++)
        {
            var coin = coinsMagnet[i];
            Vector3 directionCoin = player.position + Vector3.up * 0.75f - coin.transform.position + Vector3.forward * .25f;
            coin.transform.position += (directionCoin.normalized) * magnetSpeed * Time.fixedDeltaTime;
            if (directionCoin.sqrMagnitude < .025f)
            {
                coinsMagnet.Remove(coin);
                i--;
            }
        }
        if (magnetActive > 0)
        {
            magnetActive -= Time.fixedDeltaTime;
            if (magnetActive <= 0f) DisableMagnet();
        } 
        #endregion
    }
    public void Register(CoinItem coin)
    {
        if (!coins.Contains(coin)) coins.Add(coin);
    }
    public void Unregister(CoinItem coin)
    {
        if (coins.Contains(coin)) coins.Remove(coin);
        if (coinsMagnet.Contains(coin.transform)) coinsMagnet.Remove(coin.transform);
    }
    public void AddMagnetCoin(Transform coin)
    {
        coinsMagnet.Add(coin);
    }
    public void SetTimeMagnet(float timeUp)
    {
        if (timeUp <= 0f) return;
        magnetActive = timeUp;
        GameManager.Instance.ClearEvent.AddListener(DisableMagnet);
    }
    public void DisableMagnet()
    {
        GameManager.Instance.ClearEvent.RemoveListener(DisableMagnet);
        magnetActive = 0f;
        //coinsMagnet.Clear();
        groundMagnet.gameObject.SetActive(false);
        airMagnet.gameObject.SetActive(false);
        PowerUpInformation.Instance.CancelPU("Magnet");
    }
    public bool IsMagnet() => magnetActive > 0f;
}
