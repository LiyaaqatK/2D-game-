using UnityEngine;

public class EnemyState : EntityState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Enemy enemy;
    public EnemyState(StateMachine stateMchine, string animBoolName, Enemy enemy) : base(stateMchine, animBoolName)
    {
        this.enemy = enemy;
        rb = enemy.rb;
        anim = enemy.anim;
    }
}
