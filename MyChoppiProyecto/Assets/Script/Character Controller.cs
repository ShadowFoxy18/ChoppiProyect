using Cainos.LucidEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    CharacterBehavior cb;

    Rigidbody2D rb;
    Animator an;

    float m_moveAmt;
    bool m_isAttacking;
    bool m_isJumping;
    bool m_isInteracting;
    bool m_isDodge;
    bool m_isBlock;

    // --- Input Actions --- //
    private GamplayBehavior inputAction;

    InputAction m_MoveAction;
    InputAction m_JumpAction;
    InputAction m_AttackAction;
    InputAction m_InteractAction;
    InputAction m_DodgeAction;
    InputAction m_BlockAction;

    public bool isAttacking = false;


    private void OnEnable() => inputAction.Enable();
    private void OnDisable() => inputAction.Disable();
    // ---------------------- //

    void Awake()
    {
        inputAction = new GamplayBehavior();

        rb = transform.parent.GetComponent<Rigidbody2D>();
        an = transform.GetComponentInChildren<Animator>();

        cb = transform.parent.GetComponent<CharacterBehavior>();

        m_MoveAction = inputAction.Player.Walk;
        m_JumpAction = inputAction.Player.Jump;
        m_AttackAction = inputAction.Player.Attack;
        m_InteractAction = inputAction.Player.Interact;
        m_DodgeAction = inputAction.Player.Dodge;

        //m_JumpAction.performed += ctx => m_isJumping = true;
        //m_JumpAction.performed += ctx => m_isJumping = false;
        m_JumpAction.performed += ctx => Jump();

    }

    // Update is called once per frame
    void Update()
    {
        OnFloor();

        MoveCharacter();

        //Jump();

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

    // ----------------------- //


    // -- Character Behavior Methods -- //
    void OnFloor()
    {
        an.SetBool("Grounded", true);
    }

    bool SecondJump()
    {
        return false;
    }
}
