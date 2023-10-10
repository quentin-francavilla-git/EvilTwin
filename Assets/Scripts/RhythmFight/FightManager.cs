using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fireWork;

    [SerializeField]
    private GameObject perfectPos;

    [SerializeField]
    private GameObject playerHit;

    [SerializeField]
    private GameObject hitPos;

    [SerializeField]
    private SpawnerManager spawner;

    [SerializeField]
    private PostProcess postprocess;

    [SerializeField]
    LevelLoader levelLoader;

    AudioManager audioManager;

    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.StopAll();
        audioManager.Play("MainTheme");
    }

    public void HitPlayer(bool visualEffect = true) {
        if (visualEffect) {
            Instantiate(playerHit, hitPos.transform.position, hitPos.transform.rotation);
        }

        PlayerVariables.Damage(1);

        audioManager.Play("Hurt");

        if (PlayerVariables.currentHealth <= 0) {
            PlayerDie();
        }
    }

    public void HitEnemy()
    {
        Instantiate(fireWork, perfectPos.transform.position, perfectPos.transform.rotation);
        postprocess.BloomUp();
        FightingEnemy.health--;

        if (FightingEnemy.health <= 0) {
            EnemyDie();
        }
    }

    private void PlayerDie()
    {
        audioManager.Play("BattleLost");
        SceneManager.LoadScene("GameOver");
    }

    private void EnemyDie()
    {
        string nextLevel = FightingEnemy.isFinalBoss ? "Win" : "Swamp";

        StopFight();
        PlayerStateList.hasWonFight = true;
        PlayerVariables.Heal(12);
        audioManager.Play("BattleWin");
        levelLoader.LoadLevel(nextLevel);
    }


    private void StopFight() {
        GameObject[] forms = GameObject.FindGameObjectsWithTag("Form");

        foreach (GameObject form in forms) {
            Destroy(form);
        }
        spawner.gameObject.SetActive(false);
    }
}
