using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] float delayTime = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        //if (GameManager.instance.IsGameOver()) return;
        //SetDelayTime();
        //EnemySpawner();
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            int rdIndex = Random.Range(0, transform.childCount);
            enemy.transform.position = transform.GetChild(rdIndex).position;
            delayTime = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(delayTime);
        }
    }
    /*
    public void SetDelayTime()
    {
        lastDelayTime = delayTime - (int)(GameManager.instance.Score * 0.001) * 0.2f;
        Debug.Log(lastDelayTime);

        if (lastDelayTime <= 0.2f)
        {
            lastDelayTime = 0.2f;
        }
    }
    */
}