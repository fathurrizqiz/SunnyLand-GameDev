using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger masuk dengan: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin diambil!");
            GameManager.instance.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}
