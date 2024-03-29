using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Material[] materials;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
