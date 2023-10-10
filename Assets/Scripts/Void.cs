using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            PlayerVariables.Damage(PlayerVariables.maxHealth + PlayerVariables.maxShield);
        }
    }

}
