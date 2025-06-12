public class FallState : p_State
{
    public FallState(PlayerController ctrl) : base(ctrl)
    {

    }
    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        
    }

    public override void EnterState()
    {
        controller.ChangeAnimState("Fall", .1f);
        controller.rb.useGravity = true;
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
        if (controller.IsGrounded()) controller.ChangeState(controller.runState);
    }
}
