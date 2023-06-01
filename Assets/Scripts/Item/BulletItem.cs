using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    [SerializeField] float minY;
    [SerializeField] float maxY;
    public GameObject bulletItem;

    private void Start()
    {
        StartCoroutine(BulletProduce());
    }
    IEnumerator BulletProduce()
    {
        float randPos = Random.Range(minY, maxY);
        int randNum = Random.Range(0, 100);

        transform.position = new Vector3(12, randPos, 0);

        if (randNum < 30)
        {
            Instantiate(bulletItem, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
