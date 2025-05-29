using UnityEngine;
using UnityEngine.Events;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;
    public static PlayerState Instance {  get { return instance; } }
    [HideInInspector] public UnityEvent deathEvt;
    public Shield shield;
    private bool isShield = false;
    private bool isRocket = false;
    private void Awake()
    {
        instance = this;
    }
    public void Death()
    {
        InputManager.Instance.enabled = false;
        deathEvt?.Invoke();
    }
    public void GetShield() => isShield = true;
    public void GetRocket() => isRocket = true;
    public void DisableShiled()
    {
        isShield = false;
        shield.DisableShield();
    }
    public void DisableRocket()
    {
        isRocket = false;
    }
    public bool IsRocket() => isRocket;
    public bool IsShield() => isShield;
}
