using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackGroundRandomiser : MonoBehaviour
{
    [SerializeField] GameObject[] elements;
    [SerializeField] GameObject    m_bonus;
    [SerializeField] private int   m_nbMaxBonusOnScreen = 5;
    [SerializeField] private float m_randomBonusSpawnMinInclusive = 1;
    [SerializeField] private float m_randomBonusSpawnMaxExclusive = 10;

    // Dimensions of the scene
    [SerializeField] private float m_edgeCorner_minX;
    [SerializeField] private float m_edgeCorner_maxX;
    [SerializeField] private float m_edgeCorner_minY;
    [SerializeField] private float m_edgeCorner_maxY;

    private int   m_elementIndex;
    private int   m_numberOfElements;
    private bool  m_canCreateBonus;
    private float m_screenWidth;
    private float m_screenHeight;
    private float m_scale;
    private float m_xValue;
    private float m_yValue;
    private float m_spawnInterval;

    // Created planets in the background & their positions
    private GameObject m_instantiatedObject;
    private Vector3[]  m_planetPositions;

    // Number of bonus on screen (public and static number)
    public static int _nbBonusOnScreen;

    void Start() {
        _nbBonusOnScreen = 0;
        m_canCreateBonus = true;
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height;
        m_numberOfElements = Random.Range(3, 6);
        m_planetPositions = new Vector3[m_numberOfElements];

        if (m_randomBonusSpawnMinInclusive < 1) { m_randomBonusSpawnMinInclusive = 1; }
        if (m_randomBonusSpawnMaxExclusive < 2) { m_randomBonusSpawnMaxExclusive = 2; }
        m_spawnInterval = Random.Range(m_randomBonusSpawnMinInclusive, m_randomBonusSpawnMaxExclusive);

        for (int i = 0; i < m_numberOfElements; i++) {

            m_elementIndex = Random.Range(0, elements.Length);
            m_xValue = Random.Range(0, m_screenWidth);
            m_yValue = Random.Range(0, m_screenHeight);
            m_scale = Random.Range(1.5f, 6f);
            m_instantiatedObject = Instantiate(elements[m_elementIndex], Camera.main.ScreenToWorldPoint(new Vector3(m_xValue, m_yValue,10)), Quaternion.identity);
            m_instantiatedObject.transform.localScale = new Vector3 (m_scale, m_scale, 1);
            m_planetPositions[i] = m_instantiatedObject.transform.position;
        }
    }

    void Update() {

        if (m_canCreateBonus) {
            // Create the bonus at a random planet on screen position
            StartCoroutine(CreateBonus(m_spawnInterval));

            // Reset the spawn timer, initiate a new one
            m_spawnInterval = Random.Range(m_randomBonusSpawnMinInclusive, m_randomBonusSpawnMaxExclusive);

            // Increment the number of bonus on screen
            _nbBonusOnScreen += 1;
        }
    }

    private IEnumerator CreateBonus(float time) {

        float randomPositionX = Random.Range(m_edgeCorner_minX, m_edgeCorner_maxX);
        float randomPositionY = Random.Range(m_edgeCorner_minY, m_edgeCorner_maxY);
        Vector3 randomPosition = new (randomPositionX, randomPositionY, 0);

        Instantiate(m_bonus, randomPosition, Quaternion.identity);

        m_canCreateBonus = false;

        yield return new WaitForSeconds(time);

        m_canCreateBonus = true;
    }

}
