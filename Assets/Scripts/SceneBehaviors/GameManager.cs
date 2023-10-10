using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStateList pState;
    private LevelLoader levelLoader;

    private void Awake()
    {
        pState = FindObjectOfType<PlayerStateList>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus()
    {
        if (pState.dead) {
            PlayerVariables.currentHealth = PlayerVariables.maxHealth;
            levelLoader.LoadLevel("Swamp");
        }
    }
}
