using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject m_missilePrefab;
    [SerializeField] AudioClip[] m_laserSounds;

    AudioSource m_audioSource;
    int m_laserIndex;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) {

            Quaternion fireRotation = transform.rotation;
            Vector3 firePosition = transform.position;
            GameObject laser = Instantiate(m_missilePrefab, firePosition, fireRotation);

            if (m_laserSounds.Length != 0) {
                m_laserIndex = Random.Range(0, m_laserSounds.Length);
                laser.GetComponent<AudioSource>().PlayOneShot(m_laserSounds[m_laserIndex]);
            }
        }
    }
}
