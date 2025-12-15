using UnityEngine;

public class FuseDeathTrigger : MonoBehaviour
{
    public EnemyStateMachine LaserDoorStateMachine;

    void OnDestroy()
    {
        LaserDoorStateMachine.ChangeState("Off");
    }
}
