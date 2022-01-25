using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentBossWave;

    public WaveConfigSO GetCurrentBossWave() {
        return currentBossWave;
    }

    public void SpawnBoss() {
        foreach (WaveConfigSO wave in waveConfigs) {
            currentBossWave = wave;

            for (int i = 0; i < currentBossWave.GetEnemyCount(); i++) {
                Instantiate(currentBossWave.GetEnemyPrefab(i),
                            currentBossWave.GetStartingWaypoint().position,
                            Quaternion.Euler(0, 0, 180),
                            transform);
            }

        }
    }

    
}
