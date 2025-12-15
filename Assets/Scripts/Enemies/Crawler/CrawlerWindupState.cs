using UnityEngine;

public class CrawlerWindupState : EnemyState
{
    public override void Enter(EnemyStateMachine machine)
    {
        machine.animator.Play("Windup");
    }

    public override void Tick(EnemyStateMachine machine)
    {
            
    }

    public override void Exit(EnemyStateMachine machine)
    {

    }
}
