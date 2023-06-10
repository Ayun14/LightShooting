using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private GameObject gameSettingPanel;
    [SerializeField] private GameObject panelGameDescription;

    private void Start()
    {
        gameSettingPanel.gameObject.SetActive(false);
        panelGameDescription.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameSettingPanel.activeSelf)
            {
                Time.timeScale = 1;
                gameSettingPanel.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                gameSettingPanel.gameObject.SetActive(true);
            }
        }
    }

    public void GameDescriptionButtonClick()
    {
        gameSettingPanel.gameObject.SetActive(false);
        panelGameDescription.gameObject.SetActive(true);
    }

    public void GameDescriptionGoBackButtonClick()
    {
        gameSettingPanel.gameObject.SetActive(true);
        panelGameDescription.gameObject.SetActive(false);
    }

    public void GameExitButtonClick()
    {
        Application.Quit();
    }
}
