using UnityEngine;
using System.Collections.Generic;

public class CrawlerAIHelper : MonoBehaviour
{
    private EnemyStateMachine machine;
    private PolygonCollider2D col;
    [HideInInspector]
    public List<Collider2D> playersInDetection;
 
    void Start()
    {
        machine = GetComponent<EnemyStateMachine>();
        col = GetComponent<PolygonCollider2D>();
        playersInDetection = new List<Collider2D>();
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            machine.ChangeState("Windup");
            playersInDetection.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInDetection.Remove(other);
        }
    }

    void decideToAttack()
    {
        if (playersInDetection.Count >= 1)
        {
            machine.ChangeState("Attack");
            return;
        }
        machine.ChangeState("Idle");

    }
}
