using UnityEngine;
using UnityEngine.Events;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;
    public static PlayerState Instance {  get { return instance; } }
    [HideInInspector] public UnityEvent deathEvt;
    private bool isShield = false;
    private void Awake()
    {
        instance = this;
    }
    public void Death()
    {
        InputManager.Instance.enabled = false;
        deathEvt?.Invoke();
    }
    public void GetShiled() => isShield = true;
    public void DisableShiled() => isShield = false;
    public bool IsShield() => isShield;
}
