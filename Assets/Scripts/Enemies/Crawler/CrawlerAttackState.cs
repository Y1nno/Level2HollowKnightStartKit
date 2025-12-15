using UnityEngine;

public class CrawlerAttackState : EnemyState
{
    private Rigidbody2D rb;
    public Vector2 impulse = new Vector2(5.0f, 10.0f);

    private float linearYChangeThreshold = 1f;
    private CrawlerAIHelper aiHelper;

    public override void Enter(EnemyStateMachine machine)

    {
        machine.animator.Play("Attack");
        rb = machine.GetComponent<Rigidbody2D>();
        Vector2 attackImpulse = new Vector2(impulse.x * machine.transform.localScale.x, impulse.y);
        rb.AddForce(attackImpulse, ForceMode2D.Impulse);
        aiHelper = machine.GetComponent<CrawlerAIHelper>();
    }

    public override void Tick(EnemyStateMachine machine)
    {
        if (rb.linearVelocity.y <= linearYChangeThreshold && rb.linearVelocity.y >= -linearYChangeThreshold)
        {
            if (aiHelper.playersInDetection.Count == 0)
            { 
                machine.ChangeState("Idle");
            }
            else
            {
                machine.ChangeState("Windup");
            }

        }
    }

    public override void Exit(EnemyStateMachine machine)
    {

    }
}
