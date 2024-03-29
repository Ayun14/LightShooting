using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScripts : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LifeOn() => animator.SetBool("LifeOff", false);
    public void LifeOff() => animator.SetBool("LifeOff", true);
}