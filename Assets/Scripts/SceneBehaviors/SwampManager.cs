using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampManager : MonoBehaviour
{
    AudioManager audioManager;
    LevelLoader loader;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        loader = FindObjectOfType<LevelLoader>();
        audioManager.StopAll();
        audioManager.Play("SwampTheme");
        if (PlayerVariables.currentHealth <= 0 ) {
            PlayerVariables.currentHealth = PlayerVariables.maxHealth;
        }
    }

    private void Update() {
        if (PlayerStateList.win == true) {
            loader.LoadLevel("Win");
        }
    }
}
