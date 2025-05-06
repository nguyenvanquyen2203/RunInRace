using UnityEngine;

public class RunState : p_State
{
    public RunState(PlayerController controller) : base(controller)
    {
        
    }
    public override void EnterState()
    {
        Debug.Log("Enter RunState");
        controller.ChangeAnimState("Running", .2f);
    }

    public override void ExitState()
    {
        
    }

    public override void FixedUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void TriggerEvent(PlayerController.OnTriggerEvent evt)
    {
        
    }

    public override void Update()
    {
        //throw new System.NotImplementedException();
    }
}
