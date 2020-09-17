using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class NpcDialogueManager : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    int rndTextIndex;

    string[] dialogueNoMask = new string[] 
    {
        "You maskcoronofied me, doc!",
        "How do I look doc?",
        "Oh no, I have a mask!",
        "Arrrghhh, I was already tested.",
        "Protection on, lights off now baby!",
        "yeah Daddy!"
    };

    string[] dialogueWithMask = new string[]
    {
        "The bigger the mask the better it gets!",
        "This face can’t handle two masks at once baby.",
        "You can’t mask me doc!",
        "Are you blind or just stupid?",
        "My mask levels are over 9000!"
    };

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (this.gameObject.GetComponent<NpcController>().masked == true)
            {
                Debug.Log("NO MASK");
                SetFloatingTextWithMask();
            }
            else
            {
                Debug.Log("NO MASK");
                SetFloatingTextNoMask();
            }

            ShowFloatingText();
        }
    }

    void SetFloatingTextNoMask()
    {
        rndTextIndex = Random.Range(0, 5);
        floatingTextPrefab.GetComponentInChildren<Text>().text = dialogueNoMask[rndTextIndex];
    }

    void SetFloatingTextWithMask()
    {
        rndTextIndex = Random.Range(0, 4);
        floatingTextPrefab.GetComponentInChildren<Text>().text = dialogueWithMask[rndTextIndex];
    }

    void ShowFloatingText()
    {
        if (floatingTextPrefab.activeInHierarchy == false)
            floatingTextPrefab.SetActive(true);
    }
}