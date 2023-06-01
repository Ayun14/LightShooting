using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float topX;
    [SerializeField] float bottomX;
    [SerializeField] float topY;
    [SerializeField] float bottomY;
    [SerializeField] string nextSceneName;
    [SerializeField] float lightScore;

    float x;
    float y;
    public bool lifeUp = false;
    public bool isBulletColor = false;

    public Material[] material;
    private SpriteRenderer spriteRenderer;
    private PlayerFire playerFire;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerFire = FindObjectOfType<PlayerFire>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, y, 0);
        transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomX, topX),
            Mathf.Clamp(transform.position.y, bottomY, topY), 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ColorItem"))
        {
            Destroy(collision.gameObject);
            spriteRenderer.material = material[collision.GetComponent<Item>().randomNum];
            playerFire.randomNum = collision.GetComponent<Item>().randomNum;
            isBulletColor = true;

            GetComponent<PlayerLightBa>().TakeLightBa(lightScore);
        }
    }
    public void PlayerDie()
    {
        PlayerPrefs.SetInt("Score", GameManager.instance.Score);
        SceneManager.LoadScene(2);
    }
}