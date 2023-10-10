using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    Slider slider;

    AudioManager audioManager;
    [SerializeField] Sound.audioType type;

    void Awake()
    {
        slider = GetComponent<Slider>();
        audioManager = FindObjectOfType<AudioManager>();

        slider.value = PlayerPrefs.GetFloat(type+"Volume");
    }

    public void updateVolume()
    {
        audioManager.changeVolume(type, slider.value);
    }
}
