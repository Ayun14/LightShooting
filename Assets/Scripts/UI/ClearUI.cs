using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    public void BackToLobbyButtonClick()
    {
        SceneManager.LoadScene("Start");
    }
}
