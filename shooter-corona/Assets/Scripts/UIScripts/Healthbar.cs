﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject gameOverUI;
    public GameObject gameUI;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    public void SetMinHealth(float health)
    {
        slider.minValue = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        if (slider.value == slider.maxValue)
        {
            SoundManager.StopSound("trainstation sound", true);
            SoundManager.PlaySound("losing screen", true, false);
            gameOverUI.SetActive(true);
            gameUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}