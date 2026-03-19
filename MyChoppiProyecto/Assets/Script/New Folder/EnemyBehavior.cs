using Cainos.LucidEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [TitleHeader("Enemy Settings")]
    [Header("Enemy Stats")]
    [SerializeField] int enemySpeed = 10;
    [SerializeField] int enemySpeedAttack = 3;
    [SerializeField] int enemySpeedSpell = 6;
    [SerializeField] int attack = 20;
    [SerializeField] int spell = 30;
    [SerializeField] int enemyHealth = 100;


    // --- Getters --- //
    // Enemy Capacity
    public int EnemySpeed => enemySpeed;

    //Enemy Speed
    public int EnemySpeedAttack => enemySpeedAttack;
    public int EnemySpeedSpell => enemySpeedSpell;

    //Enemy damage
    public int Attack => attack;
    public int Spell => spell;

    //Enemy Health
    public int EnemyHealth => enemyHealth;
}
