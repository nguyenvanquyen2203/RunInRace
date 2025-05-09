using UnityEngine;

public class DieState : p_State
{
    public DieState(PlayerController ctrl) : base(ctrl)
    {

    }

    public override void EnterState()
    {
        AudioManager.Instance.PlaySFX("Death");
        Debug.Log("Enter Jump State");
        controller.ChangeAnimState("Death", .1f);
    }

    public override void ExitState()
    {
        
    }

    public override void FixedUpdate()
    {
        
    }

    public override void TriggerEvent(PlayerController.OnTriggerEvent evt)
    {
        
    }

    public override void Update()
    {
        
    }
}
