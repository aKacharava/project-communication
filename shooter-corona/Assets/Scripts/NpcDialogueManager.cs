using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class NpcDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI floatingTextPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ShowFloatingText();
            SetFloatingText();
        }
    }

    void SetFloatingText()
    {
        floatingTextPrefab.text = "blablabllalabl";
    }

    void ShowFloatingText()
    {
        if (floatingTextPrefab.gameObject.activeInHierarchy == false)
        {
            floatingTextPrefab.gameObject.SetActive(true);
        }
    }
}