using System.Collections.Generic;
using UnityEngine;

public class OffState : EnemyState
{
    public EnemyState onState;
    public float offStateLength = 2;
    public float timeInitialOffset = 0;

    private float internalTimer = 0;

    private readonly List<BoxCollider2D> disabledTriggerColliders = new List<BoxCollider2D>();

    public void Start()
    {
        internalTimer = offStateLength + timeInitialOffset;
    }

    public override void Enter(EnemyStateMachine machine)
    {
        internalTimer += offStateLength;
        //Debug.Log("Off");
        if (gameObject.transform.Find("Freeform Light 2D"))
        {
            gameObject.transform.Find("Freeform Light 2D").gameObject.SetActive(false);
        }

        disabledTriggerColliders.Clear();
        var colliders = gameObject.GetComponents<BoxCollider2D>();
        foreach (var col in colliders)
        {
            if (col != null && col.isTrigger)
            {
                col.enabled = false;
                disabledTriggerColliders.Add(col);
            }
        }
    }

    public override void Tick(EnemyStateMachine machine)
    {
        internalTimer -= Time.deltaTime;
        if (internalTimer <= 0)
        {
            machine.ChangeState(onState.stateId);
        }
    }

    public override void Exit(EnemyStateMachine machine)
    {
        for (int i = 0; i < disabledTriggerColliders.Count; i++)
        {
            var col = disabledTriggerColliders[i];
            if (col != null)
            {
                col.enabled = true;
            }
        }
        disabledTriggerColliders.Clear();
    }
}