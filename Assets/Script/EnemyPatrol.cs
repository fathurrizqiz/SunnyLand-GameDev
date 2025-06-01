using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 5f;

    private Vector2 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Gerakan horizontal (kanan–kiri)
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Hitung jarak dari posisi awal
        float distance = transform.position.x - startPos.x;

        // Jika sudah mencapai batas kiri/kanan, balik arah
        if (Mathf.Abs(distance) >= patrolDistance)
        {
            direction *= -1;

            // Balik arah sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            // Reset posisi awal agar jarak bolak-balik tetap konsisten
            startPos = transform.position;
        }
    }
}