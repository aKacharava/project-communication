using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMasked : MonoBehaviour
{
    public Text textScore;
    public GameObject victoryUI;
    public GameObject gameUI;

    int npcs;

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC_Masked").Length;
        textScore.text = "Amount NPCs Masked: " + npcs.ToString();

        ShowVictoryScreen();
    }

    void ShowVictoryScreen()
    {
        int _allNpcs = GameObject.FindGameObjectsWithTag("NPC").Length;

        if (npcs == _allNpcs)
        {
            victoryUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
