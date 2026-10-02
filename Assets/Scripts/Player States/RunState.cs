
//This is a derived class of State
//This means it inherits fields and methods from State.cs

using UnityEngine;

public class RunState : State
{
    protected float speed;
    protected float rotationSpeed;

    public RunState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running state");
        player.animator.SetBool("isWalking", true);
    }

    public override void Exit()
    {
        player.animator.SetBool("isWalking", false);
        player.rb.linearVelocityX = 0;
        player.rb.linearVelocityY = 0;
    }



    public override void Update()
    {

        TestMethod("hello");

        

        ReadInput();

        if (player.moveAction.ReadValue<Vector2>().magnitude < 0.1f)
        {
            sm.ChangeState(sm.idleState);
        }

        if (player.jumpAction.IsPressed())
        {
            sm.ChangeState(sm.jumpState);
        }

        if (player.crouchAction.IsPressed())
        {
            sm.ChangeState(sm.crouchState);
        }
        if (player.attackAction.IsPressed())
        {
            sm.ChangeState(sm.attackState);
        }

        //debug move gameObject
        player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;


        UIscript.ui.DrawText("*** This is the running state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");
        UIscript.ui.DrawText("C = Crouch State");
        UIscript.ui.DrawText("Left click = Attack State");



    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if( collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }

    public override void FixedUpdate()
    {
    }
}
