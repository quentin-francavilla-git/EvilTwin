using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }
}
