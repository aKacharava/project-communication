using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textScore;

    int npcs;

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC").Length;
        textScore.text = "Amount NPCs: " + npcs.ToString();
    }
}
