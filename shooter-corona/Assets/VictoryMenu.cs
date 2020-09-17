using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryUI;
    public GameObject gameUI;

    public void ResetGame()
    {
        victoryUI.SetActive(false);
        gameUI.SetActive(true);
}
}
