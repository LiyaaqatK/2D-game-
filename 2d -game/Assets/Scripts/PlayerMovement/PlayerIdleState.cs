using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, StateMachine stateMchine, string stateName) : base(stateMchine, stateName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (player.moveImput.x == 1 && player.facingRight || player.moveImput.x == -1 && !player.facingRight)
        {
            //Debug.Log("Running forward");
            stateMchine.ChangeState(player.moveState);
        }
        else if (player.moveImput.x == -1 && player.facingRight || player.moveImput.x == 1 && !player.facingRight)
        {
            //Debug.Log("Running backwards");

            stateMchine.ChangeState(player.moveBackWards);
        }


    }

}
