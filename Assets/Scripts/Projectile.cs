using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;

    private BulletItem bulletItem;
    private HpItem hpItem;

    private void Start()
    {
        bulletItem = FindObjectOfType<BulletItem>();
        hpItem = FindObjectOfType<HpItem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().TakeDamage(damage);
            Destroy(gameObject);
            bulletItem.BulletProduce();
            hpItem.HpProduce();
        }
    }
}
