using Cainos.LucidEditor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    CharacterBehavior cb;
    AttackCharaacter ac;

    Rigidbody2D rb;
    Animator an;

    float m_moveAmt;
    bool m_isJumping;
    bool m_isInteracting;
    bool m_isDodge;
    bool m_isBlock;


    int actualLife;
    float porcentageLife;

    int currentAttack = 0;
    float icd = 0;

    // --- Input Actions --- //
    private GamplayBehavior inputAction;

    InputAction m_MoveAction;
    InputAction m_JumpAction;
    InputAction m_AttackAction;
    InputAction m_InteractAction;
    InputAction m_DodgeAction;
    InputAction m_BlockAction;


    public bool invenciblePlayer = false;


    private void OnEnable() => inputAction.Enable();
    private void OnDisable() => inputAction.Disable();
    // ---------------------- //

    void Awake()
    {
        inputAction = new GamplayBehavior();

        rb = transform.parent.GetComponent<Rigidbody2D>();
        an = transform.GetComponentInChildren<Animator>();

        cb = transform.parent.GetComponent<CharacterBehavior>();
        ac = GetComponentInChildren<AttackCharaacter>();

        actualLife = cb.PlayerHealth;

        m_MoveAction = inputAction.Player.Walk;
        m_JumpAction = inputAction.Player.Jump;
        m_AttackAction = inputAction.Player.Attack;
        m_InteractAction = inputAction.Player.Interact;
        m_DodgeAction = inputAction.Player.Dodge;

        //m_JumpAction.performed += ctx => m_isJumping = true;
        //m_JumpAction.performed += ctx => m_isJumping = false;
        m_JumpAction.performed += ctx => Jump();

        m_AttackAction.performed += ctx => Attack();

    }

    // Update is called once per frame
    void Update()
    {
        OnFloor();

        MoveCharacter();

        //Jump();

        if (icd > 0)
        {
            icd -= Time.deltaTime;
        }



    }


    // -- Character Actions -- //
    void MoveCharacter()
    {
        m_moveAmt = m_MoveAction.ReadValue<float>();

        if (m_moveAmt != 0)
        {
            an.SetInteger("AnimState", 1);

            if (m_moveAmt < 0) transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
            else transform.GetComponentInChildren<SpriteRenderer>().flipX = false;

        } else
        {
            an.SetInteger("AnimState", 0);
        }

        Vector2 moveVector = new Vector2(rb.position.x + m_moveAmt * cb.PlayerSpeed * Time.deltaTime,
        rb.position.y);

        rb.MovePosition(moveVector);
    }

    void Jump()
    {
        m_isJumping = m_JumpAction.triggered;

        if (m_isJumping)
        {
            an.SetTrigger("Jump");
            rb.AddForce(Vector2.up * cb.PlayerJump, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (icd <= 0)
        {
            ac.Attack(ac.combos[currentAttack]);
            icd = cb.PlayerSpeedAttack;
            NextAttack(false);
        }
    }

    public void Damage(float damage)
    {
        if (!invenciblePlayer)
        {
            an.SetTrigger("Hurt");
            actualLife -= (int)damage;

            CheckLife();
        }
    }

    // ----------------------- //


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Floor"))
        {

        }
    }


    // -- Character Behavior Methods -- //
    void OnFloor()
    {
        an.SetBool("Grounded", true);
    }

    bool SecondJump()
    {
        return false;
    }

    void CheckLife()
    {
        if (actualLife <= 0)
        {
            an.SetTrigger("Death");
        } else
        {
            porcentageLife = actualLife / cb.PlayerHealth;
        }
    }

    void NextAttack(bool hevy)
    {
        if (hevy)
        {
            currentAttack = 2;
        }
        else
        {
            currentAttack += 1;
            currentAttack = currentAttack > 2 ? 0 : currentAttack;
        }
    }
}
