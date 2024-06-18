using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float      m_spawnInterval = 4.5f;

    private float m_timer;

    void Update() {

        m_timer += Time.deltaTime;
        if (m_timer >= m_spawnInterval) {
            SpawnEnemy();
            m_timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(m_enemyPrefab, transform.position, Quaternion.identity);
    }
}
