using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    EnemyBehavior eb;

    Animator an;

    int actualHealth;
    float porcentageHealth = 1;

    IEstateEnemy actualState;
    //IEstateEnemy nextState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        an = GetComponent<Animator>();
        eb = transform.parent.GetComponent<EnemyBehavior>();
        ChangeState(new PatrolState());

        actualHealth = eb.EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        actualState?.LaunchState();
    }

    public void ChangeState(IEstateEnemy newState)
    {
        if (actualState != null) actualState.ExitState();

        actualState = newState;

        actualState.StartState(this);
    }

    public void RecieveDamage(float damage)
    {
        actualHealth -= (int)damage;

        if (actualHealth < 0)
        {
            Death();
        }
        else
        {
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        porcentageHealth = (float)actualHealth / eb.EnemyHealth;
    
    }


    void Death()
    {
        Debug.Log("Enemy is dead");
        an.SetTrigger("Death");

        WaitForSeconds wait = new WaitForSeconds(5f);
        transform.parent.gameObject.SetActive(false);
    }
}
