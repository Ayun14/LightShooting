using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public Material[] material;

    PlayerFire playerFire;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        playerFire = FindObjectOfType<PlayerFire>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}