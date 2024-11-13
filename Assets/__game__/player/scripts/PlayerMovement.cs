using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float frictionCoefficient = 0.95f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetupRigidbody();
        SetupCollider();
    }

    void SetupRigidbody()
    {
        // rb.freezeRotation = true;
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void SetupCollider()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            PhysicsMaterial2D material = new PhysicsMaterial2D();
            material.friction = frictionCoefficient;
            material.bounciness = 0.1f;
            collider.sharedMaterial = material;
        }
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        rb.AddForce(movement * moveSpeed);

        // Apply friction
        if (movement.magnitude == 0)
        {
            rb.linearVelocity *= frictionCoefficient;
            rb.angularVelocity *= frictionCoefficient;
        }
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, moveSpeed);
    }
}