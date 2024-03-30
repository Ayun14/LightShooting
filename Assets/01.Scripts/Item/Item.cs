using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        colorItem,
        bulletItem,
        hpItem
    }

    [SerializeField] private ItemType itemType;
    [SerializeField] private float speed;
    public int randomNum;

    public Material[] material;
    private PlayerFire playerFire;
    private PlayerHp playerHp;

    private void Start()
    {
        playerFire = FindObjectOfType<PlayerFire>();
        playerHp = FindObjectOfType<PlayerHp>();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseItem();
            Destroy(gameObject);
        }
        void UseItem()
        {
            switch (itemType)
            {
                case ItemType.hpItem:
                    playerHp.currentHp += 2;
                    break;
                case ItemType.bulletItem:
                    playerFire.attackLevle++;
                    break;
            }
        }
    }
}
