using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CollectCoin(collision.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        // Add your coin collection logic here (e.g., increase score, play sound)
        Debug.Log("Coin collected!");
        Destroy(coin);
    }
}