using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float minHealth = 0.0f;
    public float currentHealth;
    public float healthbarTestValue = 10.0f;

    public Healthbar playerHealthbar;
    void Start()
    {
        currentHealth = minHealth;
        playerHealthbar.SetMinHealth(minHealth);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentHealth < maxHealth)
        {
            TakeDamage(healthbarTestValue);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth += damage;
        playerHealthbar.SetHealth(currentHealth);
    }
}
