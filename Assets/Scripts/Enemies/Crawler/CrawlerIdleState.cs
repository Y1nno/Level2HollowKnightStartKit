using UnityEngine;

public class CrawlerIdleState : EnemyState
{
    public float endAfter = 1f;
    public string PatrolStateID = "Patrol";

    private float internalTimer = 0f;




    public override void Enter(EnemyStateMachine machine)
    {
        machine.animator.Play("Idle");
    }

    public override void Tick(EnemyStateMachine machine)
    {
        internalTimer += Time.deltaTime;
        if (internalTimer >= endAfter)
        {
            internalTimer = 0;
            Vector3 scale = machine.gameObject.transform.localScale;
            scale.x *= -1f;
            machine.gameObject.transform.localScale = scale;
            machine.ChangeState(PatrolStateID);

        }
    }

    public override void Exit(EnemyStateMachine machine)
    {

    }
}
