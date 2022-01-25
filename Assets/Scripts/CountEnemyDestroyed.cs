using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemyDestroyed : MonoBehaviour {
    LevelManager levelManager;
    EnemySpawner enemySpawner;
    BossSpawner bossSpawner;
    GameObject[] enemyClone;

    [SerializeField] bool isFinalLevel = false;
    bool isCreatedBoss = false;


    // If number of enemy has been destroyed = max of number enemy spawner
    // => Load GoNextLevel Scene
    [SerializeField] int maxOfEnemySpawner = 40;
    //[SerializeField] int numEnemySpawnerBeforeBoss = 40;
    int numOfEnemyDestroyed = 0;

    void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        bossSpawner = FindObjectOfType<BossSpawner>();
    }

    public void increateNumEnemyDestroyed() {
        numOfEnemyDestroyed += 1;

        Debug.Log("Enemies Destroyed: " + numOfEnemyDestroyed);

        if (numOfEnemyDestroyed == maxOfEnemySpawner) {
            enemySpawner.StopAllCoroutines();
        }
    }

    public void resetNumEnemyDestroyed() {
        numOfEnemyDestroyed = 0;

        Debug.Log("Enemies Destroyed Rest: " + numOfEnemyDestroyed);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        enemyClone = GameObject.FindGameObjectsWithTag("enemyClone");

        // Spawn A Boss when enough enemies had destroyed
        if (numOfEnemyDestroyed == maxOfEnemySpawner && !isCreatedBoss) {
            isCreatedBoss = true;
            Debug.Log("Boss Spawn");
            bossSpawner.SpawnBoss();
        }

        if (numOfEnemyDestroyed >= maxOfEnemySpawner) {


            Debug.Log("Level Completed");
            if (enemyClone.Length == 0) {
                resetNumEnemyDestroyed();
                if (isFinalLevel) {
                    levelManager.LoadVictory();
                }
                else {
                    levelManager.LoadNextLevelMenu();
                }
            }
        }
    }
}
