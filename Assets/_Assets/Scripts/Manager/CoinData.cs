using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinData : MonoBehaviour
{
    private static CoinData instance;
    public static CoinData Instance { get { return instance; } }
    private int coin;
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("Coin")) coin = PlayerPrefs.GetInt("Coin");
        else coin = 0;
    }
    public int GetCoin() => coin;
    public void PlusCoin(int plusCoin)
    {
        coin += plusCoin;
        SaveCoin();
    }
    public void SaveCoin() => PlayerPrefs.SetInt("Coin", coin);
    
}
