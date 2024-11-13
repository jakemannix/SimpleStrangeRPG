using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    private enum FacingDirection { Left, Right, Up, Down }

    [Header("Movement Attributes")]
    [SerializeField] private float moveSpeed = 100f;


    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Vector2 movement = Vector2.zero;
    private FacingDirection facingDirection = FacingDirection.Right;

    private readonly int animationMoveRight = Animator.StringToHash("Anim_Move_Wizard_Right");
    private readonly int animationIdleRight = Animator.StringToHash("Anim_Move_Wizard_Idle_Right");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GatherInput();
        CalculateFacingDirection();
        UpdateAnimation();
    }

    private void GatherInput()
    {
        movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    private void MovementUpdate()
    {
        rb.linearVelocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

    private void CalculateFacingDirection()
    {
        if (movement.x > 0) {
            facingDirection = FacingDirection.Right;
        } else if (movement.x < 0) {
            facingDirection = FacingDirection.Left;
        }
        Debug.Log("current facing direction: " + facingDirection);
    }

    private void UpdateAnimation()
    {
        if (facingDirection == FacingDirection.Right) {
            spriteRenderer.flipX = false;
        } else {
            spriteRenderer.flipX = true;
        }
        if (movement.sqrMagnitude > 0) {
            animator.CrossFade(animationMoveRight, 0f);
        } else {
            animator.CrossFade(animationIdleRight, 0f);
        }   
    }

}
