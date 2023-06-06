using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02, Phase03, }

public class Boss : MonoBehaviour
{
    [SerializeField] private float bossAppearPoint = 7f;
    [SerializeField] private float bossSpeed = 3f;
    [SerializeField] private float bossDamage = 3f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserWarnPrefab;
    private BossState bossState = BossState.MoveToAppearPoint;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public float pattern1Delay = 2f; // ù ��° ���� ������
    public float pattern2Delay = 2f; // �� ��° ���� ������
    public float pattern3Delay = 2f; // �� ��° ���� ������

    private BossHp bossHp;
    public Transform[] laserPos;
    private BoxCollider2D laserCollider;
    //
    public float bulletSpeed = 5f; // �Ѿ� �ӵ�
    public float waveFrequency = 2f; // ���� �ֱ�
    public float waveAmplitude = 10f; // ���� ����

    private void OnEnable()
    {
        laserCollider = laserPrefab.GetComponent<BoxCollider2D>();
        bossHp = GetComponent<BossHp>();
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(CircleFire());
        yield return new WaitForSeconds(pattern1Delay);
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return new WaitForSeconds(pattern2Delay);
        yield return StartCoroutine(SingleFireToCenterPosition());
        yield return new WaitForSeconds(pattern3Delay);
        StartCoroutine(Start()); // ���� �ݺ� ����
    }

    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());
    }

    public IEnumerator MoveToAppearPoint()
    {
        while (true)
        {
            transform.position += Vector3.left * bossSpeed * Time.deltaTime;

            if (transform.position.x <= bossAppearPoint)
            {
                transform.position = new Vector3(7, 1, 0);
            }
            yield return null;
        }
    }
    /*
    private IEnumerator Phase01()
    {
        StartCoroutine(CircleFire());
        //bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if (curPatternCount < maxPatternCount[patternIndex])
                Invoke("CircleFire", 0.7f);
            else
                Invoke("Think", 3);
            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        StartCoroutine(HalfLaserAttack());
        //bossWeapon.StartFiring(AttackType.HalfLaserAttack);

        while (true)
        {
            yield return null;
        }
    }
    private IEnumerator Phase03()
    {
        StartCoroutine(SingleFireToCenterPosition());
        //bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        while (true)
        {
            yield return null;
        }
    }

    public void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex)
        {
            case 0:
                StartCoroutine(Phase01());
                break;
            case 1:
                StartCoroutine(Phase02());
                break;
            case 2:
                StartCoroutine(Phase03());
                break;
        }
    }
    */

    //

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f; // ���� �ֱ�
        int count = 30; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü ������ ����
        float weightAngle = 0; // ���ߵǴ� ���� (�׻� ���� ���� X)

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

    private IEnumerator HalfLaserAttack()
    {
        float attackRate = 1f;
        var random = Random.Range(0, 2);

        SpawnWarning(random);
        yield return new WaitForSeconds(attackRate);
        SpawnLaser(random);
        yield return new WaitForSeconds(0.2f);
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
        /*
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
        */

        /*
        int count = 99;

        while (count >= 0)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * 3), -100);
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.15f);
            count--;
        }
        yield return null;
        */

        float time = 0f;

        while (time <= Mathf.PI * 2) // 360��(2pi ����) ȸ������ �ݺ�
        {
            // ���� ������� �Ѿ��� �߻�
            float x = transform.position.x;
            float y = Mathf.Cos(time) * waveAmplitude;

            GameObject bullet = Instantiate(projectile, new Vector3(x, y, 0f), Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(-bulletSpeed, 0f);

            time += Time.deltaTime * waveFrequency;

            yield return new WaitForSeconds(0.15f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerHp>().TakeDamage(bossDamage);
    }
}
