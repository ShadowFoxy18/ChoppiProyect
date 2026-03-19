using System.Collections.Generic;
using UnityEngine;

public class AttackCharaacter : MonoBehaviour
{
    Transform controlGolpe;

    [SerializeField] float radioAttack = 1f;
    float dañoGolpe = 1f;

    CharacterBehavior cb;
    Animator an;

    public enum AttackType
    {
        First,
        Second,
        Heavy
    }

    void ExecuteAttack(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.First:
                dañoGolpe = cb.FirstAttack;
                an.SetTrigger("Attack1");
                radioAttack = 1f;

                Debug.Log("Primer ataque");
                break;
            case AttackType.Second:
                dañoGolpe += cb.SecondAttack;
                an.SetTrigger("Attack2");
                radioAttack = 1f;

                Debug.Log("Segundo ataque");
                break;
            case AttackType.Heavy:
                dañoGolpe += cb.HeavyAttack;
                an.SetTrigger("Attack3");
                radioAttack = 1.2f;

                Debug.Log("Ataque fuerte");
                break;
        }
    }

    public Dictionary<int, AttackType> combos = new Dictionary<int, AttackType>()
    {
        {0, AttackType.First },
        {1, AttackType.Second},
        {2, AttackType.Heavy }
    };



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlGolpe = transform;

        cb = transform.parent.transform.parent.GetComponent<CharacterBehavior>();
        an = transform.parent.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(AttackType attack)
    {
        ExecuteAttack(attack);

        Golpe();
    }


    void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controlGolpe.position, radioAttack);

        foreach (Collider2D col in objetos)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyBrain>().RecieveDamage(dañoGolpe);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioAttack);
    }
}
