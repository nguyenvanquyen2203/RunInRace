using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : p_State
{
    public IdleState(PlayerController ctrl) : base(ctrl)
    {

    }

    public override void EnterState()
    {
        controller.gameObject.layer = LayerMask.NameToLayer("Player");
        controller.ChangeAnimState("Idle");
        controller.ResetPosition();
        //controller.rb.useGravity = false;
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
