using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    [SerializeField] private GameObject gameSettingPanel;
    [SerializeField] private GameObject panelGameDescription;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameSettingPanel.activeSelf)
            {
                //Time.timeScale = 1;
                gameSettingPanel.SetActive(false);
            }
            else
            {
                //Time.timeScale = 0;
                gameSettingPanel.SetActive(true);
            }
        }
    }

    public void GameDescriptionButtonClick()
    {
        gameSettingPanel.SetActive(false);
        panelGameDescription.SetActive(true);
    }

    public void GameDescriptionGoBackButtonClick()
    {
        gameSettingPanel.SetActive(true);
        panelGameDescription.SetActive(false);
    }

    public void GameExitButtonClick()
    {
        Application.Quit();
    }
}
