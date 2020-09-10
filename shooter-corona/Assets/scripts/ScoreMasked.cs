using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMasked : MonoBehaviour
{
    public Text textScore;

    int npcs;

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC_Masked").Length;
        textScore.text = "Amount NPCs Masked: " + npcs.ToString();
    }
}
