using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int damage = 1;
    private int point = 50;
    public int randomNum;

    Vector3 direction;
    public GameObject colorItem;
    public Material[] material;
    private PlayerMovement playerMove;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMove = FindObjectOfType<PlayerMovement>();
        ColorInit();
        SetDirection();
    }
    void ColorInit()
    {
        randomNum = Random.Range(0, 4);
        spriteRenderer.material = material[randomNum];
    }
    void SetDirection()
    {
        int rd = Random.Range(0, 100);

        if (rd < 30 && playerMove != null)
        {
            direction = playerMove.transform.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * 7 /* moveSpeed*/ * Time.deltaTime;
        }
        else
        {
            direction = Vector3.left;
            transform.position += direction * 4 /* moveSpeed*/ * Time.deltaTime;
        }
    }
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.AddScore(point);
            EnemyDie();
        }
    }
    public void EnemyDie()
    {
        int rand = Random.Range(0, 100);
        if (rand < 25)
        {
            colorItem.GetComponent<SpriteRenderer>().material = material[randomNum];
            colorItem.GetComponent<Item>().randomNum = randomNum;
            Instantiate(colorItem, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}