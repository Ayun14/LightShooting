using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightBa : MonoBehaviour
{
    public static float maxLight = 1f;
    public static float currentLight;

    public float MaxLight => maxLight;
    public float CurrentLight => currentLight;

    private void Awake()
    {
        currentLight = 0;
    }

    public void TakeLightBa(float lightCude)
    {
        currentLight += lightCude;
    }
}
