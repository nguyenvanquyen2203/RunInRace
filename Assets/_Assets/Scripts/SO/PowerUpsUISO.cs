using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PowerUpUI", fileName = "PowerUpUI")]
public class PowerUpsUISO : ScriptableObject
{
    public List<PowerUpUI> powerUps = new List<PowerUpUI>();
    public Sprite GetPowerUp(string name)
    {
        return powerUps.Find(x => x.name == name).img;
    }
}

[System.Serializable]
public class PowerUpUI
{
    public string name;
    public Sprite img;
}
