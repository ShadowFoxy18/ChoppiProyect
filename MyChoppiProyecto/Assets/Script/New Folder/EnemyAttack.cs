using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform controlGolpe;

    [SerializeField] float radioAttack = 1f;
    float dañoGolpe = 1f;

    EnemyBehavior cb;
    Animator an;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlGolpe = transform;

        cb = transform.parent.GetComponent<EnemyBehavior>();
        an = transform.parent.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        Golpe();
    }


    void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlGolpe.position, radioAttack);

        foreach (Collider2D col in objetos)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<CharacterController>().Damage(dañoGolpe);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioAttack);
    }
}
