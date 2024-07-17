using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameSettingPanel;
    [SerializeField] private GameObject panelGameDescription;
    
    int score = 0;

    public int Score
    {
        get => score;
        set => score = Mathf.Max(0, value);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameSettingPanel.activeSelf)
            {
                Time.timeScale = 1;
                gameSettingPanel.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                gameSettingPanel.SetActive(true);
            }
        }
    }

    public void AddScore(int Point)
    {
        score += Point;
        Debug.Log(score);
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }

    public void BackToLobbyButtonClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void GameExitButtonClick()
    {
        Application.Quit();
    }
}
