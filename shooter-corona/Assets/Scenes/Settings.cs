using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Transform musicContainer;
    public Transform soundsContainer;

    public Transform brightnessPanel;

    public Slider brightnessSlider;
    public Slider musicSlider;
    public Slider soundsSlider;

    private CanvasGroup brightness;

    private void Start()
    {
        brightness = brightnessPanel.GetComponent<CanvasGroup>();

        brightness.alpha = (1f - brightnessSlider.value) / 2;

        UpdateSounds(musicContainer, musicSlider);

        UpdateSounds(soundsContainer, soundsSlider);
    }

    private void UpdateSounds(Transform container, Slider slider)
    {
        AudioSource[] audios = container.GetComponentsInChildren<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.volume = slider.value;
        }
    }

    public void SetMusicVolume(Slider slider)
    {
        UpdateSounds(musicContainer, slider);
    }

    public void SetSoundsVolume(Slider slider)
    {
        UpdateSounds(soundsContainer, slider);
    }

    public void SetBrightness(Slider slider)
    {
        brightness.alpha = (1f - slider.value) / 2;
    }
}
