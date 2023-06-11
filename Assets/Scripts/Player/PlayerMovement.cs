using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float topX;
    [SerializeField] private float bottomX;
    [SerializeField] private float topY;
    [SerializeField] private float bottomY;
    [SerializeField] private string nextSceneName;
    [SerializeField] private float lightScore;
    public UnityEvent sceneChangeEvent;
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

    private void Update()
    {
        Move();
    }

    private void Move()
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
        sceneChangeEvent.Invoke();
    }


}