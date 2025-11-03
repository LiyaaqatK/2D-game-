using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(StateMachine stateMchine, string animBoolName, Player player) : base(stateMchine, animBoolName, player)
    {
    }

    public override void Update()
    {
        base.Update();
        if(rb.linearVelocity.y < 0)
        {
            stateMchine.ChangeState(player.playerFalling);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMchine.ChangeState(player.jumping);
        }
    }
}
