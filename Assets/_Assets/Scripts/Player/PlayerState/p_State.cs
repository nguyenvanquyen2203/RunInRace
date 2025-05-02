using UnityEngine;

public abstract class p_State
{
    protected PlayerController controller;
    public p_State(PlayerController ctrl)
    {
        this.controller = ctrl;
    }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void TriggerEvent(PlayerController.OnTriggerEvent evt);
}
