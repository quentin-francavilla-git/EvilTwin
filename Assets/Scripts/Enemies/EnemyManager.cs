using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemies;
    private static int enemiesLenght = -1;
    private static Dictionary<string, bool> enemiesName;

    [SerializeField] const string FINAL_BOSS_NAME = "Medusa Variant";

    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemyObject");

        if (enemiesLenght == -1) {
            enemiesLenght = enemies.Length;
            SetBaseEnemiesName();
        }

        SetEnemiesName();
        DestroyKilledEnemies();
    }

    private void SetEnemiesName() {
        int i = 0;

        foreach (var enemy in enemies)
        {
            enemy.name = EnemyManager.enemiesName.ElementAt(i).Key;
            i++;
        }
    }

    private void SetBaseEnemiesName() {
        EnemyManager.enemiesName = new Dictionary<string, bool>();
        for (int i = 0; i < enemiesLenght; i++) {
            string name = "Enemy" + i;
            EnemyManager.enemiesName.Add(name, true);
        }
    }

    private void DestroyKilledEnemies() {
        int i = 0;
        foreach (var enemy in enemiesName)
        {
            if (!enemy.Value) {
                Destroy(enemies[i].transform.parent.gameObject);
            }
            i++;
        }
    }

    public void KillEnemy(GameObject enemy) {
        enemiesName[enemy.name] = false;
        Destroy(enemy.transform.parent.gameObject);
    }

    public static bool IsFinalBoss(string name)
    {
        return name == FINAL_BOSS_NAME;
    }

}
