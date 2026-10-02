using UnityEngine;

public class AttackState : State
{
    public AttackState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering attack state");
        player.animator.SetBool("isAttacking", true);
    }

    // Update is called once per frame
    public override void Update()
    {
        
        if(player.myAction == PlayerScript.AnimationActions.Attack)
        {
            sm.ChangeState(sm.idleState);
        }

        UIscript.ui.DrawText("*** This is the Attack state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("C = Crouch State");
    }


    public override void Exit()
    {
        player.animator.SetBool("isAttacking", false);
        player.myAction = 0;
    }

    

}
