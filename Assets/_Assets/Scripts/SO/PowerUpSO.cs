using System;
using UnityEngine;

[Serializable]
public class PowerUpSO
{
    public float timeActive;
    public Sprite image;
    public string namePU;
    public int upgradeCost;
    public PowerUpSO(float timeActive, Sprite image, string namePU, int upgradeCost)
    {
        this.timeActive = timeActive;
        this.image = image;
        this.namePU = namePU;
        this.upgradeCost = upgradeCost;
    }
}
