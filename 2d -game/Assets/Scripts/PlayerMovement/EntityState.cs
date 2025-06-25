using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMchine;
    protected string animBoolName;

    protected Animator anim;
    protected Rigidbody2D rb;


    public EntityState(StateMachine stateMchine, string animBoolName, Player player)
    {
        this.stateMchine = stateMchine;
        this.animBoolName = animBoolName;
        this.player = player;
        anim = player.anim;
        rb = player.rb;
    }

    public virtual void Enter()
    {
        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
        
    }
}
