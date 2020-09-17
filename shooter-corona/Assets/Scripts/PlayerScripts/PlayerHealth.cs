using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float minHealth = 0.0f;
    public float currentHealth;
    public float infectByHealthyRate = 0.2f;
    public float infectBySickRate = 0.5f;

    public Healthbar playerHealthbar;
    void Start()
    {
        currentHealth = minHealth;
        playerHealthbar.SetMinHealth(minHealth);

    }

    public void DamagePlayer(float damage)
    {
        currentHealth += damage;
        playerHealthbar.SetHealth(currentHealth);
    }
    public void HealPlayer(float damage)
    {
        currentHealth -= damage;
        playerHealthbar.SetHealth(currentHealth);
    }

}
