using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
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
        panelGameDescription.gameObject.SetActive(true);
    }

    public void GameDescriptionGoBackButtonClick()
    {
        panelGameDescription.gameObject.SetActive(true);
    }
}
