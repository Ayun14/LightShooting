using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;
    [SerializeField] private BGMController bgmController;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject panelBossHP;
    private void Awake()
    {
        boss.SetActive(false);
        panelBossHP.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        //if (GameManager.instance.IsGameOver()) return;
        //SetDelayTime();
        //EnemySpawner();
    }

    IEnumerator SpawnEnemy()
    {
        PlayerLightBa.currentLight = 0;

        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            int rdIndex = Random.Range(0, transform.childCount);
            enemy.transform.position = transform.GetChild(rdIndex).position;
            delayTime = Random.Range(0.5f, 1f);

            if (PlayerLightBa.currentLight >= PlayerLightBa.maxLight)
            {
                StartCoroutine(SpawnBoss());
                break;
            }
            yield return new WaitForSeconds(delayTime);
        }
    }

    IEnumerator SpawnBoss()
    {
        bgmController.ChangeBGM(BGMType.Boss);

        yield return new WaitForSeconds(0.1f);

        panelBossHP.SetActive(true);
        boss.SetActive(true);

        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}