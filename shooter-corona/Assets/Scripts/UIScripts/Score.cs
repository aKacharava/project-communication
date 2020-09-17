using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textScore;
    public GameObject victoryUI;
    public GameObject gameUI;

    int npcs;
    int maskedNpcs;

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC").Length;
        maskedNpcs = GameObject.FindGameObjectsWithTag("NPC_Masked").Length;
        textScore.text = "Amount NPCs: " + maskedNpcs.ToString() + "/" + npcs.ToString();

        ShowVictoryScreen();
    }

    void ShowVictoryScreen()
    {
        if (maskedNpcs == npcs)
        {
            SoundManager.StopSound("trainstation sound", true);
            SoundManager.PlaySound("victory sound", true, false);
            victoryUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
