using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Vector3[]  m_spawnPoints = new Vector3[8];
    [SerializeField] private Vector3[]  m_initialSpawnPoints = new Vector3[4];
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private float      m_spawnInterval = 5;
    [SerializeField] TextMeshProUGUI    m_scoreText;

    protected float m_timer;

    public static int _bigAsteroids;
    public static int _playerScore;

    void Start()
    {
        _bigAsteroids = 0;
        _playerScore = 0;

        for (int i = 0; i < 4; i++)
        {
            SpawnEnemy(m_initialSpawnPoints[i]);
        }
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer >= m_spawnInterval && _bigAsteroids <= 4)
        {
            SpawnEnemy(m_spawnPoints[Random.Range(0, 8)]);
            m_timer = 0f;
        }

        m_scoreText.text = _bigAsteroids.ToString();
    }

    void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject newEnemy = Instantiate(m_enemyPrefab, spawnPosition, Quaternion.identity);
        _bigAsteroids++;
    }
}
