using UnityEngine;

public class JumpState : p_State
{
    public JumpState(PlayerController controller) : base(controller)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Enter Jump State");
        controller.Jump();
        controller.ChangeAnimState("Jump", .1f);
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
        if (controller.GetVelocity().y < 0f) 
        {
            if (controller.IsGrounded()) controller.ChangeState(controller.runState);
        }
    }
}
