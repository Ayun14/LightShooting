using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Image panelUI;
    [SerializeField] private Image panelGameDescription;


    private void Start()
    {
        panelUI.gameObject.SetActive(false);
        panelGameDescription.gameObject.SetActive(false);
    }
    public void SettingButtonClick()
    {
        panelUI.gameObject.SetActive(true);
    }

    public void GoBackButtonClick()
    {
        panelUI.gameObject.SetActive(false);
    }

    public void GameExitButtonClick()
    {
        Application.Quit();
    }

    public void GameDescriptionButtonClick()
    {
        panelUI.gameObject.SetActive(false);
        panelGameDescription.gameObject.SetActive(true);
    }

    public void GameDescriptionGoBackButtonClick()
    {
        panelUI.gameObject.SetActive(true);
        panelGameDescription.gameObject.SetActive(false);
    }
}
