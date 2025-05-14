using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<GameObject> lights;
    private void OnEnable()
    {
        if (GameModeManager.Instance.GetCurrentMode() == GameModeManager.ModeType.NightMode)
        {
            foreach (var light in lights) light.SetActive(true);
        } 
        else
        {
            foreach (var light in lights) light.SetActive(false);
        }
    }
}
