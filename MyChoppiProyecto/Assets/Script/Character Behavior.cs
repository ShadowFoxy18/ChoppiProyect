using Cainos.LucidEditor;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [TitleHeader("Character Settings")]
    [Header("Player Stats")]
    [SerializeField] int playerSpeed = 10;
    [SerializeField] int playerJump = 5;
    [SerializeField] int playerSpeedAttack = 3;
    [SerializeField] int firstAttack = 20;
    [SerializeField] int secondAttack = 30;
    [SerializeField] int hevyAttack = 60;
    [SerializeField] int playerHealth = 100;


    // --- Getters --- //
    // PLayer Capacity
    public int PlayerSpeed => playerSpeed;
    public int PlayerJump => playerJump;

    //Player Speed
    public int PlayerSpeedAttack => playerSpeedAttack;

    //Player damage
    public int FirstAttack => firstAttack;
    public int SecondAttack => secondAttack;
    public int HevyAttack => hevyAttack;

    //Player Health
    public int PlayerHealth => playerHealth;
}
