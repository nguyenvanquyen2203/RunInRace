using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : p_State
{
    public SlideState(PlayerController ctrl) : base(ctrl)
    {
        
    }

    public override void EnterState()
    {
        AudioManager.Instance.PlaySFX("Jump");
        Debug.Log("Enter Slide State");
        controller.ChangeAnimState("Slide", .1f);
    }

    public override void ExitState()
    {
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
}
