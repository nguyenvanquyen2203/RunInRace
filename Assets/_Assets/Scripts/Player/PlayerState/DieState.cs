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
        controller.rb.velocity = Vector3.zero;
        controller.gameObject.layer = LayerMask.NameToLayer("Invisible");
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
