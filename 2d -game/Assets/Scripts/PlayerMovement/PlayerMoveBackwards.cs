using UnityEngine;

public class PlayerMoveBackwards : EntityState
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

        player.SetVelocity(player.moveImput.x * player.moveSpeed, rb.linearVelocity.y);

    }
}
