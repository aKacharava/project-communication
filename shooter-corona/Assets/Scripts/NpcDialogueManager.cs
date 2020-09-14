using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NpcDialogueManager : MonoBehaviour
{
    public GameObject floatingTextPrefab;
    GameObject checkDuplicateObj;

    void Start()
    {
        checkDuplicateObj = GameObject.Find("FloatingText");
    }

    void Update()
    {
        CheckForDuplicates();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ShowFloatingText();
        }
    }

    void CheckForDuplicates()
    {
        // Check if floating text exists in game
        if (checkDuplicateObj != null)
        {
            Debug.Log("IT EXISTS");
            //Destroy(floatingTextPrefab);
        }
    }

    void ShowFloatingText()
    {
        Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
    }
}
