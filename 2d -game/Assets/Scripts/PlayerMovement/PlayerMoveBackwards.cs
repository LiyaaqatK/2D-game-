using UnityEngine;

public class PlayerMoveBackwards : PlayerGroundedState
{
    public PlayerMoveBackwards(Player player, StateMachine stateMchine, string animBoolName) : base(stateMchine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();
        if (player.moveImput.x == 0)
        {
            stateMchine.ChangeState(player.idleState);
        }

        if(player.moveImput.x > 0 && player.facingRight == true|| player.moveImput.x < 0 && player.facingRight == false)
        {
            stateMchine.ChangeState(player.moveState);
        }
        player.SetVelocity(player.moveImput.x * player.moveSpeed, rb.linearVelocity.y);

    }
}
