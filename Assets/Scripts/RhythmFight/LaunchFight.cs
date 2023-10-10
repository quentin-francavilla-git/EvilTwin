using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchFight : MonoBehaviour
{
    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    private EnemyManager enemyManager;

    private const int ENEMY_LAYER = 7;

    private void Awake() {
        if (PlayerStateList.hasWonFight) {
            WinFight();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == ENEMY_LAYER) {
            StartFight(other);
        }
    }

    private void StartFight(Collision2D enemy) {
        PlayerVariables.levelPosition = transform.position;
        FightingEnemy.name = enemy.gameObject.name;
        FightingEnemy.sprite = enemy.gameObject.GetComponent<SpriteRenderer>().sprite;
        FightingEnemy.health = enemy.gameObject.GetComponent<EnemyVariables>().maxHealth;
        FightingEnemy.isFinalBoss = EnemyManager.IsFinalBoss(enemy.transform.parent.name) ? true : false;
        levelLoader.LoadLevel("RhythmCombat");
        // Play Sound
        FindObjectOfType<AudioManager>().Play("LaunchBattle");
    }

    private void WinFight() {
        PlayerStateList.hasWonFight = false;
        GameObject enemyKilled = GameObject.Find(FightingEnemy.name);
        IsGameWin(enemyKilled);
        enemyManager.KillEnemy(enemyKilled);
        transform.position = PlayerVariables.levelPosition;
    }

    // Win condition
    private void IsGameWin(GameObject killed) {
        if (EnemyManager.IsFinalBoss(killed.transform.parent.name)) {
            levelLoader.LoadLevel("Win");
        }
    }


}
