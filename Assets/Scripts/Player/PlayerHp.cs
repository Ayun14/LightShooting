using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] float maxHp = 10;
    public float currentHp;

    public float MaxHp => maxHp;
    public float CurrentHp => currentHp;

    PlayerMovement playerMovement;
    Animator animator;
    private void Awake()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        StartCoroutine(HitAnimation());
        StopCoroutine(HitAnimation());

        if (currentHp <= 0)
            playerMovement.PlayerDie();
        else if (currentHp >= 10)
            currentHp = 10;
    }

    private IEnumerator HitAnimation()
    {
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Hit", false);
    }
}
