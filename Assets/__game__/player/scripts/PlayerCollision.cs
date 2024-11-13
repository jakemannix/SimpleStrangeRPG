using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private int coinsCollected = 0;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"PlayerCollision Start method called. Current health: {currentHealth}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                CollectCoin(collision.gameObject);
                break;
            case "Creature":
                TakeDamage(10); // Adjust damage amount as needed
                break;
            // You can add more cases here as needed
            default:
                // Optional: handle untagged or unexpected collisions
                break;
        }
    }

    private void CollectCoin(GameObject coin)
    {
        coinsCollected++;
        Debug.Log($"Coin collected! Total coins: {coinsCollected}");
        Destroy(coin);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // Add your game over logic here
    }
}
