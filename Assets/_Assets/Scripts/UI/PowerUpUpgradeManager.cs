using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpUpgradeManager : MonoBehaviour
{
    public List<PUUpgradeUI> upgrades;
    public TextMeshProUGUI coinText;
    private void Start()
    {
        foreach (var upgrade in upgrades)
        {
            upgrade.SetManager(this);
        }
    }
    private void OnEnable()
    {
        ResetPUUpgradeUI();
    }
    public void ResetPUUpgradeUI()
    {
        coinText.text = CoinData.Instance.GetCoin().ToString();
        foreach (var upgrade in upgrades)
        {
            upgrade.ResetPUUpgradeUI();
        }
    }
}
