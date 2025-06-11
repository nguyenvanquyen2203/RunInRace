using UnityEngine;

public class RunState : p_State
{
    public RunState(PlayerController controller) : base(controller)
    {
        
    }

    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        if (!controller.IsGrounded()) return;
        if (evt == PlayerController.OnActionEvent.Jump) controller.ChangeState(controller.jumpState);
        if (evt == PlayerController.OnActionEvent.Slide) controller.ChangeState(controller.slideState);
    }

    public override void EnterState()
    {
        controller.ChangeAnimState("Running", .2f);
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
        controller.RotatePlayer();
    }
}
