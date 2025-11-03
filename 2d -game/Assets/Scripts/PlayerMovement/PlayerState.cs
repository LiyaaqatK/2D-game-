using UnityEngine;

public abstract class PlayerState : EntityState
{
    protected Player player;
    


    public PlayerState(StateMachine stateMchine, string animBoolName, Player player) : base(stateMchine, animBoolName)
    {
        
        this.player = player;
        anim = player.anim;
        rb = player.rb;
    }

    public override void Enter()
    {
        base.Enter();
        anim.SetBool(animBoolName, true);
    }

    public override void Update()
    {
        base.Update();
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        anim.SetBool(animBoolName, false);
        
    }
}
