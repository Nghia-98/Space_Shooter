using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderItems : MonoBehaviour
{

    ItemSpawner itemSpawner;
    WaveConfigSO waveConfig;

    List<Transform> waypoints;
    int waypointIndex = 0;

    CountEnemyDestroyed enemiesDestroyed;

    void Awake() {
        itemSpawner = FindObjectOfType<ItemSpawner>();
        enemiesDestroyed = FindObjectOfType<CountEnemyDestroyed>();
    }


    void Start() {
        waveConfig = itemSpawner.GetCurrentItemWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update() {
        FollowItemPath();
    }

    void FollowItemPath() {
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
