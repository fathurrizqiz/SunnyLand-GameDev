using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Coba ambil EnemyPlants
            EnemyPlants enemy = other.GetComponent<EnemyPlants>();
            if (enemy != null)
            {
                enemy.TakeDamage(999); // damage besar agar langsung mati
            }

            // Pantulkan player ke atas
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, 10f); // mantul ke atas
            }
        }
    }
}
