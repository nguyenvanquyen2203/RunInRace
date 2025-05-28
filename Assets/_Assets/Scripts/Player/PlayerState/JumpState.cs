using UnityEngine;

public class JumpState : p_State
{
    public JumpState(PlayerController controller) : base(controller)
    {
        
    }

    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Enter Jump State");
        AudioManager.Instance.PlaySFX("Jump");
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
        controller.Move();
        if (controller.rb.velocity.y < -0.5f) 
        {
            if (controller.IsGrounded()) controller.ChangeState(controller.runState);
        }
    }
}
