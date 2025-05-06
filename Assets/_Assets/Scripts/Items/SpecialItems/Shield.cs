using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerState playerState;
    private float activeTime;
    private void Start()
    {
        playerState = PlayerState.Instance;
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (activeTime <= 0)
        {
            playerState.DisableShiled();
            gameObject.SetActive(false);
            return; 
        } 
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        activeTime -= Time.fixedDeltaTime;
    }
    public void ActiveShield(float uptime)
    {
        transform.position = playerState.transform.position + Vector3.up * 0.75f;
        activeTime = uptime;
        playerState.GetShiled();
        PowerUpInformation.Instance.ActivePowerUp("Shield");
    }
}