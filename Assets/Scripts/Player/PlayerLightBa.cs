using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightBa : MonoBehaviour
{
    [SerializeField] float maxLight = 1;
    private float currentLight;

    public float MaxLight => maxLight;
    public float CurrentLight => currentLight;

    private void Awake()
    {
        currentLight = 0;
    }
    public void TakeLightBa(float lightCude)
    {
        currentLight += lightCude;

        if (currentLight >= maxLight)
        {
            Debug.Log("**보스 출현**");
        }
    }
}
