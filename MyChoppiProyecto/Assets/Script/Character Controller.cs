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


    private void OnEnable() => inputAction.Enable();
    private void OnDisable() => inputAction.Disable();
    // ---------------------- //

    void Awake()
    {
        inputAction = new GamplayBehavior();

        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

        cb = GetComponent<CharacterBehavior>();

        m_MoveAction = inputAction.Player.Walk;
        m_JumpAction = inputAction.Player.Jump;
        m_AttackAction = inputAction.Player.Attack;
        m_InteractAction = inputAction.Player.Interact;
        m_DodgeAction = inputAction.Player.Dodge;




    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();

        if (m_JumpAction.WasPressedThisFrame() && (OnFloor() || SecondJump()))
        {
            Jump();
        }

    }




    // -- Character Actions -- //
    void MoveCharacter()
    {
        m_moveAmt = m_MoveAction.ReadValue<float>();

        Vector2 moveVector = new Vector2(rb.position.x + m_moveAmt * cb.PlayerSpeed * Time.deltaTime,
        rb.position.y);

        rb.MovePosition(moveVector);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * cb.PlayerJump, ForceMode2D.Impulse);
    }

    // ----------------------- //


    // -- Character Behavior Methods -- //
    bool OnFloor()
    {
        return true;
    }

    bool SecondJump()
    {
        return false;
    }
}
