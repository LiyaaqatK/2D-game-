using UnityEngine;

public class PlayerMoveState : EntityState
{
    public PlayerMoveState(Player player, StateMachine stateMchine, string stateName) : base(stateMchine, stateName, player)
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
