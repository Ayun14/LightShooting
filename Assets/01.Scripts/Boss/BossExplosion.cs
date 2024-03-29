using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private string sceneName;

    public void Setup(PlayerMovement playerMovement, string sceneName)
    {
        this.playerMovement = playerMovement;
        this.sceneName = sceneName;
    }

    private void OnDestroy()
    {
        GameManager.instance.AddScore(10000);
        PlayerPrefs.SetInt("Score", GameManager.instance.Score);
        SceneManager.LoadScene("Clear");
    }
}
