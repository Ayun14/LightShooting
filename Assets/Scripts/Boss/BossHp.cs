using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHp : MonoBehaviour
{
    [SerializeField] private float maxHP = 1000;
    private float currentHP;
    private int bossPoint = 5000;

    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            GameManager.instance.AddScore(bossPoint);
            SceneManager.LoadScene("Clear");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = Color.white;
    }
}
