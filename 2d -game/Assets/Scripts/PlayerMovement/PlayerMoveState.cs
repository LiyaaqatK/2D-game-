using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
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
        if (player.moveImput.x > 0 && player.facingRight == false || player.moveImput.x < 0 && player.facingRight == true)
        {
            stateMchine.ChangeState(player.moveBackWards);
        }
        player.SetVelocity(player.moveImput.x * player.moveSpeed, rb.linearVelocity.y);
        
    }
}
