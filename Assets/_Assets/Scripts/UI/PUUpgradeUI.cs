using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PUUpgradeUI : MonoBehaviour
{
    public string namePU;
    public TextMeshProUGUI namePUUpgrade;
    public TextMeshProUGUI timeActive;
    public TextMeshProUGUI upgradeCost;
    public Image PUImg;
    public Button upgradeBtn;
    private PowerUpUpgradeManager manager;
    private int costUpgrade;
    public void SetManager(PowerUpUpgradeManager _manager) => this.manager = _manager;
    public void ResetPUUpgradeUI()
    {
        PowerUpSO pu = PowerUpInformation.Instance.powerUpInfor.GetPowerUp(namePU);
        namePUUpgrade.text = namePU;
        timeActive.text = pu.timeActive.ToString();
        PUImg.sprite = pu.image;
        costUpgrade = pu.upgradeCost;
        upgradeCost.text = costUpgrade.ToString();
        if (costUpgrade > CoinData.Instance.GetCoin()) upgradeBtn.interactable = false;
        else upgradeBtn.interactable = true;

    }
    public void UpgradeBtn()
    {
        PowerUpInformation.Instance.powerUpInfor.UpgradePU(0.1f, namePU);
        CoinData.Instance.PlusCoin(-costUpgrade);
        manager.ResetPUUpgradeUI();
        //ResetPUUpgradeUI();
    }
}
