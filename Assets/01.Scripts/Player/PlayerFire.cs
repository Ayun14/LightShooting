using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    public Material[] material;
    public int attackLevle = 1;
    public int colorNum;
    public GameObject _bullet;

    private AudioSource audioSource;
    public Transform _bulletPar;
    private PlayerMovement playerMovement;
    private Projectile projectile;
    private SoundOptions soundOptions;

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
        audioSource = GetComponent<AudioSource>();
        soundOptions = FindObjectOfType<SoundOptions>();
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AttackByLevel();
                soundOptions.PlaySFX();
                //audioSource.Play();
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
                    bullet.GetComponent<SpriteRenderer>().material = material[colorNum];
                }
                break;
            case 2:
                GameObject bullet2 = Instantiate(_bullet, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                bullet2.transform.parent = _bulletPar;

                GameObject bullet22 = Instantiate(_bullet, transform.position + Vector3.down * 0.2f, Quaternion.identity);
                bullet22.transform.parent = _bulletPar;

                if (playerMovement.isBulletColor == true)
                {
                    bullet2.GetComponent<SpriteRenderer>().material = material[colorNum];
                    bullet22.GetComponent<SpriteRenderer>().material = material[colorNum];
                }
                break;
            case 3:
                GameObject bullet3 = Instantiate(_bullet, transform.position, Quaternion.identity);
                bullet3.transform.parent = _bulletPar;

                GameObject bullet33 = Instantiate(_bullet, transform.position + Vector3.up * 0.4f, Quaternion.identity);
                bullet33.transform.parent = _bulletPar;

                GameObject bullet333 = Instantiate(_bullet, transform.position + Vector3.down * 0.4f, Quaternion.identity);
                bullet333.transform.parent = _bulletPar;

                if (playerMovement.isBulletColor == true)
                {
                    bullet3.GetComponent<SpriteRenderer>().material = material[colorNum];
                    bullet33.GetComponent<SpriteRenderer>().material = material[colorNum];
                    bullet333.GetComponent<SpriteRenderer>().material = material[colorNum];
                }
                break;
            default:
                GameObject bullet4 = Instantiate(_bullet, transform.position, Quaternion.identity);
                bullet4.transform.parent = _bulletPar;

                GameObject bullet44 = Instantiate(_bullet, transform.position + Vector3.up * 0.4f, Quaternion.identity);
                bullet44.transform.parent = _bulletPar;

                GameObject bullet444 = Instantiate(_bullet, transform.position + Vector3.down * 0.4f, Quaternion.identity);
                bullet444.transform.parent = _bulletPar;

                if (playerMovement.isBulletColor == true)
                {
                    bullet4.GetComponent<SpriteRenderer>().material = material[colorNum];
                    bullet44.GetComponent<SpriteRenderer>().material = material[colorNum];
                    bullet444.GetComponent<SpriteRenderer>().material = material[colorNum];
                }
                break;
        }

    }
}