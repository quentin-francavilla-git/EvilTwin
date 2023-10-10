using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake() {
        audioManager  = FindObjectOfType<AudioManager>();
        audioManager.StopAll();
        audioManager.Play("MainTheme");
    }
}
