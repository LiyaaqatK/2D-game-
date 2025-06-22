using UnityEngine;

public class PlayerIdleState : EntityState
{
    public PlayerIdleState(Player player, StateMachine stateMchine, string stateName) : base(stateMchine, stateName, player)
    {
    }


    public override void Update()
    {
        base.Update();
        if (player.moveImput.x != 0)
        {
            stateMchine.ChangeState(player.moveState);
        }

      
    }

}
