using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<GameObject> lights;
    private void OnEnable()
    {
        //foreach (var light in lights) light.SetActive(false);
    }
    public void ActiveLight()
    {
        foreach (var light in lights) light.SetActive(true);
    }
    private void OnDisable()
    {
        foreach (var light in lights) light.SetActive(false);
    }
}
