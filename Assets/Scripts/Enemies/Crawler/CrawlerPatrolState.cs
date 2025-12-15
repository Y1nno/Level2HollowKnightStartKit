using UnityEngine;

//[CreateAssetMenu(menuName = "Scripts/Enemies/Woodie/Patrol")]
public class CrawlerPatrolState : EnemyState
{
    public float pauseEvery = 1f;
    public string IdleStateID = "Idle";
    public Mover controlledMover;

    private float internalTimer = 0f;

    [HideInInspector] public PatrollingEnemyController patrolController;

    public override void Enter(EnemyStateMachine machine)
    {
        if (controlledMover == null)
        {
            controlledMover = machine.gameObject.GetComponent<Mover>();
        }
        patrolController = machine.GetComponent<PatrollingEnemyController>();
        if (patrolController != null)
        {
            patrolController.enabled = true;
        }
        machine.animator.Play("Walk");
    }

    public override void Tick(EnemyStateMachine machine)
    {
        internalTimer += Time.deltaTime;
        if (internalTimer >= pauseEvery)
        {
            internalTimer = 0;
            machine.ChangeState(IdleStateID);

        }

        controlledMover.AccelerateInDirection(new Vector3(-machine.gameObject.transform.localScale.x, 0f, 0f));
    }

    public override void Exit(EnemyStateMachine machine)
    {
        if (patrolController != null)
        {  patrolController.enabled = false; }
    }
}
