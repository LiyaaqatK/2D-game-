using UnityEngine;

public class PlayerFalling : PlayerAirState
{
    public PlayerFalling(Player player, StateMachine stateMchine, string animBoolName) : base(stateMchine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();
        if(player.groundDetected)
        {
            stateMchine.ChangeState(player.idleState);
        }
        
    }
}
