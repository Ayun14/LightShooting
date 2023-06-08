using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 2;

    private void Update()
    {
        if (transform.position.x < -10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
