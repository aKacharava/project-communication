using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject gameUI;

    public void ResetGame()
    {
        victoryUI.SetActive(false);
        gameUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
