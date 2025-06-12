using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PowerUpInformation : MonoBehaviour
{
    private static PowerUpInformation instance;
    public static PowerUpInformation Instance { get { return instance; } }
    //[SerializeField] public PowerUpInforSO powerUpInfor;
    public PowerUpsUISO powerUpsUI;
    public PowerUpData powerUpData;
    public List<PowerUp> powerUps;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadDefaultData();
        //Save();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(powerUpData);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }
    public void LoadData()
    {
        if (!File.Exists(Application.dataPath + "/save.txt"))
        {
            Debug.Log("Don't exists save.txt");
            return;
        }
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        powerUpData = JsonUtility.FromJson<PowerUpData>(saveString);
    }
    public void LoadDefaultData()
    {
        powerUpData = new PowerUpData();
    }
    public PowerUpSO GetPU(string name)
    {
        PowerUpInfor pU = powerUpData.GetPU(name);
        return new PowerUpSO(pU.timeActive, powerUpsUI.GetPowerUp(name), name, pU.upgradeCost);
    }
    public void UpgradePU(float timeUp, string name)
    {
        PowerUpInfor pU = powerUpData.GetPU(name);
        pU.timeActive += timeUp;
        pU.timeActive = (float)Math.Round((double)pU.timeActive, 1);
        if (pU.upgradeCost < 10) pU.upgradeCost++;
        else pU.upgradeCost = (int)(pU.upgradeCost * 1.1f);
        //Save();
    }
    public void ActivePowerUp(string name)
    {
        foreach (var pU in powerUps)
        {
            if (pU.CheckPowerUp(name))
            {
                pU.ResetActive();
                return;
            }
        }
        PowerUpSO powerUp = GetPU(name);
        foreach (var pU in powerUps)
        {
            if (!pU.isActive)
            {
                pU.Active(powerUp);
                return;
            }
        }
    }
    public void CancelPU(PowerUp pU)
    {
        int index = powerUps.FindIndex(x => x == pU);
        if (index == -1) return;
        for (int i = index; i < powerUps.Count - 1; i++)
        {
            if (!powerUps[i + 1].isActive)
            {
                powerUps[i].isActive = false;
                powerUps[i].gameObject.SetActive(false);
                return;
            }
            powerUps[i].gameObject.SetActive(true);
            (Sprite currentImg, string currentName, float currentMaxTime, float currentCurrTime) = powerUps[i + 1].GetPUUI();
            powerUps[i].ChangePUUI(currentImg, currentName, currentMaxTime, currentCurrTime);
            powerUps[i + 1].isActive = false;
            powerUps[i + 1].gameObject.SetActive(false);
        }
    }
    public void ClearPU()
    {
        for (int i = powerUps.Count - 1; i >= 0; i--) CancelPU(powerUps[i]);
    }
    public void CancelPU(string name)
    {
        PowerUp pU = powerUps.Find(element => element.GetName() == name);
        CancelPU(pU);
    }
}
[System.Serializable]
public class PowerUpData
{
    public PowerUpInfor[] powerUps;
    public PowerUpData(PowerUpInforSO info)
    {
        powerUps = new PowerUpInfor[info.powerUps.Count];
        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i] = new PowerUpInfor(info.powerUps[i].namePU, info.powerUps[i].timeActive, info.powerUps[i].upgradeCost);
        }
    }
    public PowerUpData()
    {
        powerUps = new PowerUpInfor[4];
        powerUps[0] = new PowerUpInfor("Shield", 6f, 20);
        powerUps[1] = new PowerUpInfor("Magnet", 6f, 20);
        powerUps[2] = new PowerUpInfor("ScoreBoost", 6f, 20);
        powerUps[3] = new PowerUpInfor("Rocket", 10f, 30);
    }
    public PowerUpInfor GetPU(string name)
    {
        return Array.Find(powerUps, PowerUp => PowerUp.namePU == name);
    }
}
[System.Serializable]
public class PowerUpInfor
{
    public string namePU;
    public float timeActive;
    public int upgradeCost;
    public PowerUpInfor(string name,  float timeActive, int upgradeCost)
    {
        this.namePU = name;
        this.timeActive = timeActive;
        this.upgradeCost = upgradeCost;
    }
}