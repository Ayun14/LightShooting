using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    public GameObject bulletItem;
    public void BulletProduce()
    {
        int randNum = Random.Range(0, 100);

        if (randNum <= 3)
        {
            GameObject BulletItem = Instantiate(bulletItem);
            int rdIndex = Random.Range(0, transform.childCount);
            BulletItem.transform.position = transform.GetChild(rdIndex).position;
        }
    }
}