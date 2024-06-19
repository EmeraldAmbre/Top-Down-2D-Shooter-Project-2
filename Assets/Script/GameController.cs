using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Vector3[]  m_spawnPoints = new Vector3[8];
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float      m_spawnInterval = 6;

    protected float m_timer;

    public static int _bigAsteroids;

    void Start()
    {
        _bigAsteroids = 0;
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer >= m_spawnInterval && _bigAsteroids <= 4)
        {
            SpawnEnemy();
            m_timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = m_spawnPoints[Random.Range(0, 8)];
        GameObject newEnemy = Instantiate(m_enemyPrefab, spawnPosition, Quaternion.identity);
        _bigAsteroids++;
    }
}
