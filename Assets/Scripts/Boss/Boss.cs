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
    [SerializeField] private float rushSpeed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject laserWarnPrefab;
    [SerializeField] private GameObject explosionPrefab;
    private BossState bossState = BossState.MoveToAppearPoint;
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    public float pattern1Delay = 2f; // 첫 번째 패턴 딜레이
    public float pattern2Delay = 2f; // 두 번째 패턴 딜레이
    public float pattern3Delay = 2f; // 세 번째 패턴 딜레이

    private BossHp bossHp;
    public Transform[] laserPos;
    private BoxCollider2D laserCollider;
    private Transform player;

    // 원 공격
    private float weightAngle = 0; // 가중되는 각도 (항상 같은 각도 X)

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        laserCollider = laserPrefab.GetComponent<BoxCollider2D>();
        bossHp = GetComponent<BossHp>();
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(CircleFire());
        yield return StartCoroutine(CircleFire());
        yield return StartCoroutine(CircleFire());
        yield return StartCoroutine(CircleFire());
        yield return StartCoroutine(CircleFire());
        yield return new WaitForSeconds(pattern1Delay);
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return StartCoroutine(HalfLaserAttack());
        yield return new WaitForSeconds(pattern2Delay);
        yield return StartCoroutine(SingleFireToCenterPosition());
        yield return new WaitForSeconds(pattern3Delay);
        StartCoroutine(Start()); // 패턴 반복 실행

        // BossHP 체크
        //if (bossHp.CurrentHP <= bossHp.MaxHP * 0.7f || bossHp.CurrentHP <= bossHp.MaxHP * 0.3f)
        //{
        //    StopCoroutine(Start());

        //    StartCoroutine(BossRush());
        //    yield return new WaitForSeconds(1f);
        //    StopCoroutine(BossRush());

        //    StartCoroutine(Start());
        //}
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

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f; // 공격 주기
        int count = 29; // 발사체 생성 개수
        float intervalAngle = 360 / count; // 발사체 사이의 각도

        for (int i = 0; i < count; ++i)
        {
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);

            float angle = weightAngle + intervalAngle * i;

            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

            clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));

            weightAngle += 1;
        }

        yield return new WaitForSeconds(attackRate);

    }

    private IEnumerator HalfLaserAttack()
    {
        float attackRate = 1f;
        var random = Random.Range(0, 2);

        SpawnWarning(random);
        yield return new WaitForSeconds(attackRate);
        SpawnLaser(random);
        yield return new WaitForSeconds(0.08f);
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
        int count = 59;
        float patternCount = 1f;

        while (count >= 0)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(-1, Mathf.Cos(Mathf.PI * 10 * patternCount / 100));
            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.15f);
            patternCount++;
            count--;
        }
        yield return null;
    }

    private IEnumerator BossRush()
    {
        // 플레이어가 존재하지 않으면 리턴
        if (player == null)
            StopCoroutine(BossRush());

        // 플레이어 방향으로 보스가 돌진
        if (transform.position.x > -10)
        {
            Vector2 direction = player.position - transform.position;
            transform.Translate(direction * rushSpeed * Time.deltaTime);
        }
        transform.position = new Vector3(10, 1, 0);
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveToAppearPoint());

    }

    public void OnDie()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerHp>().TakeDamage(bossDamage);
    }
}
