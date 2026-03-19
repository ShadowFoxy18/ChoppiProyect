using UnityEngine;

public class AttackState : IEstateEnemy
{
    EnemyBrain eb;

    public void StartState(EnemyBrain stateEnemy)
    {
        eb = stateEnemy;

        Debug.Log("Start Attack State");
    }

    public void LaunchState()
    {
        Debug.Log("Launch Attack State");
    }

    public void ExitState()
    {
        Debug.Log("Exit Attack State");
    }
}
