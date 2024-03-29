using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum AttackType { CircleFire = 0, HalfLaserAttack = 1, SingleFireToCenterPosition = 2,}

public class BossWeapon : MonoBehaviour
{
    /*
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserWarnPrefab;

    public Transform[] laserPos;
    private BoxCollider2D laserCollider;
    private Boss boss;

    private void Start()
    {
        laserCollider = laserPrefab.GetComponent<BoxCollider2D>();
        boss = GetComponent<Boss>();
    }
    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f; // 공격 주기
        int count = 30; // 발사체 생성 개수
        float intervalAngle = 360 / count; // 발사체 사이의 각도
        float weightAngle = 0; // 가중되는 각도 (항상 같은 각도 X)

        for (int i = 0; i < count; ++i)
        {
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);

            // 발사체 이동 방향 (각도)
            float angle = weightAngle + intervalAngle * i;

            // 발사체 이동 방향 (벡터)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

            // 발사체 이동 방향 설정
            clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
        }

        // 발사체가 생성되는 시작 각도 설정을 위한 변수
        weightAngle += 1;

        boss.curPatternCount++;

        yield return new WaitForSeconds(attackRate);
    }

    private IEnumerator HalfLaserAttack()
    {
        float attackRate = 1f;
        var random = Random.Range(0, 2);

        SpawnWarning(random);
        yield return new WaitForSeconds(attackRate);
        SpawnLaser(random);

        boss.curPatternCount++;

        if (boss.curPatternCount < boss.maxPatternCount[boss.patternIndex])
            Invoke("HalfLaserAttack", 0.1f);
        else
            Invoke("Think", 3);
    }

    void SpawnWarning(int random)
    {
        var warning = Instantiate(laserWarnPrefab, laserPos[random].position, Quaternion.identity, transform);
        warning.GetComponent<SpriteRenderer>().DOFade(0, 1f);

        if (warning.GetComponent<SpriteRenderer>().color.a <= 0) Destroy(warning);
    }

    void SpawnLaser(int random)
    {
        var laser = Instantiate(laserPrefab, laserPos[random].position, Quaternion.identity, transform);
        laser.transform.DOScaleY(0, 1.2f);

        if (laser.transform.localScale.y <= 0) Destroy(laser);
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 1f;
        float setTime = 10f;

        if (setTime >= 0)
        {
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            clone.GetComponent<Movement2D>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
            setTime -= attackRate;
        }

        boss.curPatternCount++;

        if (boss.curPatternCount < boss.maxPatternCount[boss.patternIndex])
            Invoke("SingleFireToCenterPosition", 0.15f);
        else
            Invoke("Think", 3);
    }
    */
}
