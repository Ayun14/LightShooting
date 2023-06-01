using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLightBaViewer : MonoBehaviour
{
    [SerializeField] PlayerLightBa playerLight;

    Slider sliderLight;
    private void Awake()
    {
        sliderLight = GetComponent<Slider>();
    }
    void Update()
    {
        LightBaUpdate();
    }
    void LightBaUpdate()
    {
        sliderLight.value = playerLight.CurrentLight;
    }
}
