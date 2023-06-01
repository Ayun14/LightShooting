using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    [SerializeField] float minY;
    [SerializeField] float maxY;
    public GameObject hpItem;

    private void OnEnable()
    {
        StartCoroutine(HpProduce());
    }

    private void Start()
    {
        //StartCoroutine(HpProduce());
    }

    IEnumerator HpProduce()
    {
        int randNum = Random.Range(0, 100);

        if (randNum <= 100)
        {
            GameObject HpItem = Instantiate(hpItem);
            int rdIndex = Random.Range(0, transform.childCount);
            HpItem.transform.position = transform.GetChild(rdIndex).position;
            yield return new WaitForSeconds(1f);
        }
    }
}
