using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Image powerUpImg;
    public Scrollbar powerUpScrbar;
    private string powerUpName;
    private float maxTimeActive;
    private float currentTimeActive;
    public bool isActive;

    // Update is called once per frame
    void FixedUpdate()
    {
        powerUpScrbar.size = currentTimeActive / maxTimeActive;
        if (currentTimeActive > 0) currentTimeActive -= Time.fixedDeltaTime;
        else UnactivePU();
    }
    public bool CheckPowerUp(string name)
    {
        return isActive && this.powerUpName == name;
    }
    public void ResetActive()
    {
        powerUpScrbar.size = 1;
        currentTimeActive = maxTimeActive;
    }
    public void Active(PowerUpSO pU)
    {
        isActive = true;
        gameObject.SetActive(true);
        powerUpName = pU.namePU;
        powerUpImg.sprite = pU.image;
        maxTimeActive = pU.timeActive;
        ResetActive();
    }
    public void UnactivePU()
    {
        PowerUpInformation.Instance.CancelPU(this);
        //PowerUpManager.Instance.CancelPU(this);
    }
    public (Sprite, string, float, float) GetPUUI()
    {
        return (powerUpImg.sprite, powerUpName, maxTimeActive, currentTimeActive);
    }
    public void ChangePUUI(Sprite img, string name, float mTime, float currTime)
    {
        powerUpImg.sprite = img;
        powerUpName = name;
        maxTimeActive = mTime;
        currentTimeActive = currTime;
        if (!isActive)
        {
            isActive = true;
            gameObject.SetActive(true);
        }
    }
    public string GetName() => powerUpName;
}
