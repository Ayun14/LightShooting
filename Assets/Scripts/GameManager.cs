using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] TextMeshProUGUI scoreText;
    //GameObject player;
    //PlayerMovement playerMove;

    bool isGameOver;
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
        //playerMove = FindObjectOfType<PlayerMovement>();
    }
    public void AddScore(int Point)
    {
        score += Point;
        Debug.Log(score);
        UpdateScoreText();
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }
}
