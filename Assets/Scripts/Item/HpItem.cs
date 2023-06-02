using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    public GameObject hpItem;

    private void Start()
    {
        StartCoroutine(HpProduce());
    }

    IEnumerator HpProduce()
    {
        while (true)
        {
            int randNum = Random.Range(0, 100);

            if (randNum <= 1)
            {
                GameObject HpItem = Instantiate(hpItem);
                int rdIndex = Random.Range(0, transform.childCount);
                HpItem.transform.position = transform.GetChild(rdIndex).position;
                yield return new WaitForSeconds(5f);
            }
            yield return null;
        }
    }
}
