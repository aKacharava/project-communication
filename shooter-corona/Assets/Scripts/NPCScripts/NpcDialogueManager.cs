using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class NpcDialogueManager : MonoBehaviour
{
    public GameObject floatingTextPrefab;

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
        floatingTextPrefab.GetComponent<TextMesh>().text = "blablabllalabl";
    }

    void ShowFloatingText()
    {
        if (floatingTextPrefab.gameObject.activeInHierarchy == false)
        {
            floatingTextPrefab.gameObject.SetActive(true);
        }
    }
}