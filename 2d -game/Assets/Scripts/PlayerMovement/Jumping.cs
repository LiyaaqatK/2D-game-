using UnityEngine;

public class Jumping : PlayerAirState
{
    private bool groundCheck = true;
    public Jumping(Player player, StateMachine stateMchine, string animBoolName) : base(stateMchine, animBoolName, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(rb.linearVelocity.x, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        if(rb.linearVelocity.y < 0)
        {
            stateMchine.ChangeState(player.playerFalling);
        }
    }

}
