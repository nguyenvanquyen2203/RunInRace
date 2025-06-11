using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : p_State
{
    Vector3 slidePos;
    public SlideState(PlayerController ctrl) : base(ctrl)
    {
        
    }

    public override void EnterState()
    {
        slidePos = controller.transform.position;
        AudioManager.Instance.PlaySFX("Slide");
        controller.ChangeAnimState("Slide", .1f);
    }

    public override void ExitState()
    {
        controller.transform.position = new Vector3(controller.transform.position.x, slidePos.y, slidePos.z);
        controller.ResetCollider();

    }

    public override void FixedUpdate()
    {
        
    }

    public override void Update()
    {
        
    }
    public override void TriggerEvent(PlayerController.OnTriggerEvent evt)
    {
        controller.ChangeState(controller.runState);
    }

    public override void ActionEvent(PlayerController.OnActionEvent evt)
    {
        if (evt == PlayerController.OnActionEvent.Jump) controller.ChangeState(controller.jumpState);
    }
}
