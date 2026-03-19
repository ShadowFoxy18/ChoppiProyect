using UnityEngine;

public class ChachState :   IEstateEnemy
{
    EnemyBrain eb;
    public void StartState(EnemyBrain stateEnemy)
    {
        eb = stateEnemy;

        Debug.Log("Start Chach State");
    }

    public void LaunchState()
    {
        Debug.Log("Launch Chach State");
    }

    public void ExitState()
    {
        Debug.Log("Exit Chach State");
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
