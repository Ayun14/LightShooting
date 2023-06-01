using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpViewer : MonoBehaviour
{
    [SerializeField] PlayerHp playerHp;

    Slider sliderHp;
    private void Awake()
    {
        sliderHp = GetComponent<Slider>();
    }
    void Update()
    {
        HpUpdate();
    }
    void HpUpdate()
    {
        sliderHp.value = playerHp.CurrentHp / playerHp.MaxHp;
    }
}
