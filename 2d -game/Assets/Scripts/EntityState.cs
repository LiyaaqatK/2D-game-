using UnityEngine;

public abstract class EntityState
{
    protected StateMachine stateMchine;
    protected string animBoolName;

    protected Animator anim;
    protected Rigidbody2D rb;

    public EntityState(StateMachine stateMchine, string animBoolName)
    {
        this.stateMchine = stateMchine;
        this.animBoolName = animBoolName;

    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
}
