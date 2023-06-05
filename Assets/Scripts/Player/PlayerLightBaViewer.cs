using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLightBaViewer : MonoBehaviour
{
    [SerializeField] private PlayerLightBa playerLight;

    private Slider sliderLight;
    private void Awake()
    {
        sliderLight = GetComponent<Slider>();
    }
    private void Update()
    {
        LightBaUpdate();
    }
    private void LightBaUpdate()
    {
        sliderLight.value = playerLight.CurrentLight;

        if (playerLight.CurrentLight >= playerLight.MaxLight)
        {
            sliderLight.gameObject.SetActive(false);
        }
    }
}
