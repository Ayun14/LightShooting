using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Image panelUI;

    public void SettingButtonClick()
    {
        panelUI.gameObject.SetActive(true);
    }

    public void GoBackButtonClick()
    {
        panelUI.gameObject.SetActive(false);
    }

    public void GameExitButton()
    {
        Application.Quit();
    }
}
