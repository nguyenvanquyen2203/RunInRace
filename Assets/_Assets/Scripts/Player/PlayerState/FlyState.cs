using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyState : p_State
{
    public FlyState(PlayerController controller) : base(controller)
    {
        
    }

    public override void EnterState()
    {
        controller.ChangeAnimState("Flying", 1f);
        controller.rb.useGravity = false;
        controller.transform.DOMoveY(5, 1f);
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerEvent(PlayerController.OnTriggerEvent evt)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
