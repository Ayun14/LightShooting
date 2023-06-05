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
        float attackRate = 0.5f; // ���� �ֱ�
        int count = 30; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü ������ ����
        float weightAngle = 0; // ���ߵǴ� ���� (�׻� ���� ���� X)

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);

                // �߻�ü �̵� ���� (����)
                float angle = weightAngle + intervalAngle * i;

                // �߻�ü �̵� ���� (����)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                // �߻�ü �̵� ���� ����
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }

            // �߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }
}
