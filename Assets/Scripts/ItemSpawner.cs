using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 15f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentItemWave;
 
    void Start() {
        StartCoroutine(SpawnItemsWaves());
    }

    public WaveConfigSO GetCurrentItemWave() {
        return currentItemWave;
    }

    IEnumerator SpawnItemsWaves() {
        yield return new WaitForSeconds(5f);
        do {
            foreach (WaveConfigSO wave in waveConfigs) {
                currentItemWave = wave;

                for (int i = 0; i < currentItemWave.GetEnemyCount(); i++) {
                    Instantiate(currentItemWave.GetEnemyPrefab(i),
                                currentItemWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);

                    yield return new WaitForSeconds(currentItemWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
