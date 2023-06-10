using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    public Material[] material;
    public int attackLevle = 1;
    public int randomNum;

    public GameObject _bullet;
    public Transform _bulletPar;
    private PlayerMovement playerMovement;
    private Projectile projectile;

    public int AttckByLevel
    {
        get => attackLevle;
        set => attackLevle = Mathf.Max(1, 3);
    }

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        projectile = FindObjectOfType<Projectile>();
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AttackByLevel();
                yield return new WaitForSeconds(_delayTime);
            }

            yield return null;
        }
    }

    public void AttackByLevel()
    {
        switch (attackLevle)
        {
            case 1:
                GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
                bullet.transform.parent = _bulletPar;

                if (playerMovement.isBulletColor == true)
                {
                    bullet.GetComponent<SpriteRenderer>().material = material[randomNum];
                }
                break;
            case 2:
                GameObject bullet2 = Instantiate(_bullet, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                bullet2.transform.parent = _bulletPar;

                GameObject bullet22 = Instantiate(_bullet, transform.position + Vector3.down * 0.2f, Quaternion.identity);
                bullet22.transform.parent = _bulletPar;

                if (playerMovement.isBulletColor == true)
                {
                    bullet2.GetComponent<SpriteRenderer>().material = material[randomNum];
                    bullet22.GetComponent<SpriteRenderer>().material = material[randomNum];
                }
                break;
            case 3:
                GameObject bullet3 = Instantiate(_bullet, transform.position, Quaternion.identity);
                bullet3.transform.parent = _bulletPar;

                GameObject bullet33 = Instantiate(_bullet, transform.position + Vector3.up * 0.4f, Quaternion.identity);
                bullet33.transform.parent = _bulletPar;

                GameObject bullet333 = Instantiate(_bullet, transform.position + Vector3.down * 0.4f, Quaternion.identity);
                bullet333.transform.parent = _bulletPar;


                // 레이저 구현 뒤 5~10초 후 다시 attackLevel = 1로

                if (playerMovement.isBulletColor == true)
                {
                    bullet3.GetComponent<SpriteRenderer>().material = material[randomNum];
                    bullet33.GetComponent<SpriteRenderer>().material = material[randomNum];
                    bullet333.GetComponent<SpriteRenderer>().material = material[randomNum];
                }
                break;
            default:
                attackLevle = 3;
                break;
        }

    }
}