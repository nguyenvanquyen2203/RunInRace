using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : p_State
{
    public FallState(PlayerController ctrl) : base(ctrl)
    {

    }
    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState()
    {
        controller.ChangeAnimState("Fall", .1f);
        controller.rb.useGravity = true;
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
        controller.RotatePlayer();
        if (controller.IsGrounded()) controller.ChangeState(controller.runState);
    }
}
