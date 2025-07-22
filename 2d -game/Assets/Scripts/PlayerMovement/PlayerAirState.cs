using UnityEngine;

public class PlayerAirState : EntityState
{
    public PlayerAirState(StateMachine stateMchine, string animBoolName, Player player) : base(stateMchine, animBoolName, player)
    {
    }
    public override void Update()
    {
        base.Update();
        if (player.moveImput.x != 0)
        {
            player.SetVelocity(player.moveImput.x * (player.moveSpeed * player.inAirMoveForce), rb.linearVelocity.y);
        }
    }
}
