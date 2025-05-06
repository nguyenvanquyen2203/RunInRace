using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PowerUpInfor", fileName = "PowlerUpInfor")]
public class PowerUpInforSO : ScriptableObject
{
    public List<PowerUpSO> powerUps = new List<PowerUpSO>();
    public PowerUpSO GetPowerUp(string name)
    {
        return powerUps.Find(x => x.namePU == name);
    }
    public void UpgradePU(float timeUp, string name)
    {
        foreach (var powerUp in powerUps)
        {
            if (powerUp.namePU == name)
            {
                powerUp.timeActive += timeUp;
                if (powerUp.upgradeCost < 10) powerUp.upgradeCost++;
                else powerUp.upgradeCost = (int)(powerUp.upgradeCost * 1.1f);
                powerUp.timeActive = (float)Math.Round(powerUp.timeActive, 2);
                return;
            }
        }
    }
}
