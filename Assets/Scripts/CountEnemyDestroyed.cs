using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemyDestroyed : MonoBehaviour {
    LevelManager levelManager;
    EnemySpawner enemySpawner;
    GameObject[] enemyClone;


    // If number of enemy has been destroyed = max of number enemy spawner
    // => Load GoNextLevel Scene
    [SerializeField] int maxOfEnemySpawner = 30;
    int numOfEnemyDestroyed = 0;

    void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
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
        Debug.Log("Enemy Clone: " + enemyClone.Length);

        if (numOfEnemyDestroyed >= maxOfEnemySpawner) {


            Debug.Log("Level Completed");
            if (enemyClone.Length == 0) {
                resetNumEnemyDestroyed();
                levelManager.LoadNextLevelMenu();
            }
        }
    }
}