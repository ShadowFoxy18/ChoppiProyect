using UnityEngine;

public class PatrolState : IEstateEnemy
{
    EnemyBrain eb;
    public void StartState(EnemyBrain stateEnemy)
    {
        eb = stateEnemy;
        Debug.Log("Start Patrol State");
    }
    public void LaunchState()
    {
        Debug.Log("Launch Patrol State");
    }
    public void ExitState()
    {
        Debug.Log("Exit Patrol State");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
