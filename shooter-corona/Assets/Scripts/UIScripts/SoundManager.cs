using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static Settings settings;

    private void Start()
    {
        settings = GameObject.Find("Menu Settings").transform.GetComponent<Settings>();
    }

    public void Press()
    {
        PlaySound("buttons feedback", true, false);
    }

    public static void StopSound(string name, bool isMusic)
    {
        Transform sound = settings.Sound(name, isMusic);

        if (sound != null)
        {
            AudioSource audio = sound.GetComponent<AudioSource>();

            audio.Stop();
        }

        else
        {
            Debug.Log($"{name} doesn't exist in sounds...");
        }
    }

    public static void PlaySound(string name, bool overload, bool isMusic)
    {
        Transform sound = settings.Sound(name, isMusic);

        if (sound != null)
        {
            AudioSource audio = sound.GetComponent<AudioSource>();

            if(!overload && !audio.isPlaying)

                audio.Play();

            else if(overload)

                audio.Play();
        }

        else
        {
            Debug.Log("Sound doesn't exist...");
        }
    }
}
