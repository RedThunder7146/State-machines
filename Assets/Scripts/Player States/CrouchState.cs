using UnityEngine;

public class CrouchState : State
{
    public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }


    public override void Enter()
    {
        // this method is called when the state begins
        Debug.Log("entering crouch state");
        player.animator.SetBool("isCrouching", true);
    }



    public override void Update()
    {
        //check for leaf state - Jump, Walk, Idle
        if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
        {
            sm.ChangeState(sm.runState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        if (player.interactAction.IsPressed())
        {
            sm.ChangeState(sm.idleState);
        }

        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        UIscript.ui.DrawText("*** This is the Crouch state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");
        UIscript.ui.DrawText("Left click = Attack State");

    }


    public override void Exit()
    {
        player.animator.SetBool("isCrouching", false);
    }




}
