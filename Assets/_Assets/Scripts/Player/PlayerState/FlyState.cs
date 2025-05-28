using DG.Tweening;

public class FlyState : p_State
{
    public FlyState(PlayerController controller) : base(controller)
    {
        
    }

    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        if (evt == PlayerController.OnActionEvent.EndFlying) controller.ChangeState(controller.fallState);
    }

    public override void EnterState()
    {
        controller.ResetForce();
        controller.ChangeAnimState("Flying", 1f);
        controller.rb.useGravity = false;
        controller.transform.DOMoveY(5, 1f);
    }

    public override void ExitState()
    {
        //throw new System.NotImplementedException();
    }

    public override void FixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void TriggerEvent(PlayerController.OnTriggerEvent evt)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        controller.Move();
    }
}
