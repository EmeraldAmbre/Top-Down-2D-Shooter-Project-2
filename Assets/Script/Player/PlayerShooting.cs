using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject m_missilePrefab;
    AudioSource m_audioSource;
    [SerializeField] AudioClip[] m_laserSounds;
    int m_laserIndex;


    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            Quaternion fireRotation = transform.rotation;
            Vector3 firePosition = transform.position;
            GameObject laser = Instantiate(m_missilePrefab, firePosition, fireRotation);
            if (m_laserSounds.Length != 0)
            {
                m_laserIndex = Random.Range(0, m_laserSounds.Length);
                laser.GetComponent<AudioSource>().PlayOneShot(m_laserSounds[m_laserIndex]);
            }
        }
    }
}
