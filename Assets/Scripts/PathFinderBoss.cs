using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderBoss : MonoBehaviour {
    BossSpawner bossSpawner;
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointIndex = 0;

    CountEnemyDestroyed enemiesDestroyed;

    void Awake() {
        bossSpawner = FindObjectOfType<BossSpawner>();
        enemiesDestroyed = FindObjectOfType<CountEnemyDestroyed>();
    }


    void Start() {
        waveConfig = bossSpawner.GetCurrentBossWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }
    private void FixedUpdate() {
        FollowPathBoss();
    }

    //void FixUpdate() {
    //    FollowPathBoss();
    //}

    void FollowPathBoss() {
        if (waypointIndex < waypoints.Count) {

            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            Vector2 targetPosition = waypoints[waypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if ((Vector2)transform.position == targetPosition) {
                waypointIndex++;
                if (waypointIndex >= waypoints.Count) {
                    waypointIndex = 0;
                }
            }
        }
    }
}
