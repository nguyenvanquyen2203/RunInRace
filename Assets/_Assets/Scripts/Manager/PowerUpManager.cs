using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private static PowerUpManager instance;
    public static PowerUpManager Instance { get { return instance; } }
    public PowerUpInforSO powerUpInfor;
    public List<PowerUp> powerUps;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
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
        PowerUpSO powerUp = powerUpInfor.GetPowerUp(name);
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
            (Sprite currentImg, string currentName, float currentMaxTime, float currentCurrTime) = powerUps[i+1].GetPUUI();
            powerUps[i].ChangePUUI(currentImg, currentName, currentMaxTime, currentCurrTime);
            powerUps[i + 1].isActive = false;
            powerUps[i + 1].gameObject.SetActive(false);
        }
    }
}
