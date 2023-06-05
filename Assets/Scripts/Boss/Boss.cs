using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02, Phase03, }

public class Boss : MonoBehaviour
{
    [SerializeField] private float bossAppearPoint = 7f;
    [SerializeField] private float bossSpeed = 3f;
    private BossState bossState = BossState.MoveToAppearPoint;

    private Movement2D movement2D;
    private BossWeapon bossWeapon;

    private void Start()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        while (true)
        {
            transform.position += Vector3.left * bossSpeed * Time.deltaTime;

            if (transform.position.x <= bossAppearPoint)
            {
                transform.position = new Vector3(7, 1, 0);
            }
            /*
            int rand = Random.Range(0, 3);

            switch (rand)
            {
                case 0:
                    ChangeState(BossState.Phase01);
                    break;
                case 1:
                    ChangeState(BossState.Phase02);
                    break;
                case 2:
                    ChangeState(BossState.Phase03);
                    break;
            }
            */
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            yield return null;
        }
    }
    private IEnumerator Phase02()
    {
        bossWeapon.StartFiring(AttackType.HalfLaserAttack);

        while (true)
        {
            yield return null;
        }
    }
    private IEnumerator Phase03()
    {
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        while (true)
        {
            yield return null;
        }
    }
}
