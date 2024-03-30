using UnityEngine;

public class BulletItem : MonoBehaviour
{
    public GameObject bulletItem;
    private PlayerFire playerFire;

    private void Start()
    {
        playerFire = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFire>();
    }

    public void BulletProduce()
    {
        int randNum = Random.Range(0, 100);

        if (randNum <= 1 && playerFire.attackLevle <= 3)
        {
            GameObject BulletItem = Instantiate(bulletItem);
            int rdIndex = Random.Range(0, transform.childCount);
            BulletItem.transform.position = transform.GetChild(rdIndex).position;
        }
    }
}
