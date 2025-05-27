using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageCooldown = 1f;
    private float lastAttackTime;

    [SerializeField] private HealthUI playerHealth;

    private void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<HealthUI>();
            if (playerHealth == null)
                Debug.LogWarning("HealthUI tidak ditemukan di scene!");
        }
    }

   
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        TryAttack(collision);
    }


    private void TryAttack(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Dapatkan posisi player dan enemy
            Vector2 playerPos = collision.transform.position;
            Vector2 enemyPos = transform.position;

            // Jika player tidak di atas enemy (y player <= y enemy + toleransi)
            if (playerPos.y <= enemyPos.y + 0.5f)
            {
                if (Time.time - lastAttackTime > damageCooldown)
                {
                    if (playerHealth != null)
                    {
                        Debug.Log("Player kena damage dari monster");
                        playerHealth.TakeDamage(1);
                        lastAttackTime = Time.time;
                    }
                }
            }
        }
    }
}
