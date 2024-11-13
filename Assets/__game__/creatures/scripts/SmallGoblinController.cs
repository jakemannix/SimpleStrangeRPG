using UnityEngine;

public class SmallGoblinController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float viewingDistance = 5f;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float moveSpeed = 50f;

    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        // Find the player by tag - make sure your player has the "Player" tag!
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerTransform == null) 
        {
            Debug.LogWarning("No player found!");
            return;
        }

        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        // If player is within viewing distance but outside attack distance
        if (distanceToPlayer <= viewingDistance && distanceToPlayer > attackDistance)
        {
            // Calculate direction to player
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            Vector2 velocity = direction * moveSpeed * Time.fixedDeltaTime;
                        
            // Move towards player
            rb.linearVelocity = velocity;
        }
        else if (distanceToPlayer <= attackDistance)
        {
            // attack the player, once we have attack logic
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            // can't see the player. Can later insert logic for patrolling, etc.
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw viewing distance (blue)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewingDistance);
        
        // Draw attack distance (red)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
