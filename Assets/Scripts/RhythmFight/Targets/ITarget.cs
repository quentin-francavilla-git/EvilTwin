using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITarget : MonoBehaviour
{
    public FightManager fightManager;

    private void Start() {
        GameObject fightManagerObject = GameObject.Find("FightManager");

        fightManager = fightManagerObject.GetComponent<FightManager>();
    }

    public virtual void Action() {
        // Play Sound
        if (gameObject.tag == "OkTarget" || gameObject.tag == "GoodTarget")
            FindObjectOfType<AudioManager>().Play("OkHit");
        if (gameObject.tag == "PerfectTarget")
            FindObjectOfType<AudioManager>().Play("PerfectHit");
    }

    public void WrongKey() {
        fightManager.HitPlayer(false);
    }
}
