using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    public GameObject hpItem;

    public void HpProduce()
    {
        int randNum = Random.Range(0, 100);

        if (randNum < 1)
        {
            GameObject HpItem = Instantiate(hpItem);
            int rdIndex = Random.Range(0, transform.childCount);
            HpItem.transform.position = transform.GetChild(rdIndex).position;
        }
    }
}
