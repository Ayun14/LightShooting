using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    public GameObject bulletItem;

    private void Start()
    {
        StartCoroutine(BulletProduce());
    }
    IEnumerator BulletProduce()
    {
        while (true)
        {
            int randNum = Random.Range(0, 100);

            if (randNum <= 1)
            {
                yield return new WaitForSeconds(10f);
                GameObject BulletItem = Instantiate(bulletItem);
                int rdIndex = Random.Range(0, transform.childCount);
                BulletItem.transform.position = transform.GetChild(rdIndex).position;
            }
            yield return null;
        }
    }
}
