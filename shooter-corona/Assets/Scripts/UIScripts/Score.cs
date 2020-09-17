using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textScore;

    int npcs;
    int maskedNpcs;

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC").Length;
        maskedNpcs = GameObject.FindGameObjectsWithTag("NPC_Masked").Length;
        textScore.text = "Amount NPCs: " + maskedNpcs.ToString() + "/" + npcs.ToString();
    }
}
