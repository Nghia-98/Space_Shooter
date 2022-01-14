using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }


    void Start() {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update() {
        FollowPath();
    }

    void FollowPath() {
        if (waypointIndex < waypoints.Count) {

            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            Vector2 targetPosition = waypoints[waypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if ((Vector2)transform.position == targetPosition) {
                waypointIndex++;
            }
        }
        else {
            Destroy(gameObject);
        }
    }
}
