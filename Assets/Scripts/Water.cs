using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private PlayerStateList pState;
    AudioManager audioManager;

    private void Awake()
    {
        pState = FindObjectOfType<PlayerStateList>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            audioManager.Play("AcidAttack");
            PlayerVariables.Damage(6);
        }
    }
}
