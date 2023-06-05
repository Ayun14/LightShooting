using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, }

public class BossWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

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

        while (true)
        {
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

            yield return new WaitForSeconds(attackRate);
        }
    }
}
