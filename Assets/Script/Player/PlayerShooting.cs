using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject m_missilePrefab;
    AudioSource m_audioSource;
    [SerializeField] AudioClip[] m_laserSounds;
    int m_laserIndex;

    private void Start()
    {
     m_audioSource = GetComponent<AudioSource>();  
        
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            Quaternion fireRotation = transform.rotation;
            Vector3 firePosition = transform.position;
            Instantiate(m_missilePrefab, firePosition, fireRotation);
            m_laserIndex = Random.Range(0, m_laserSounds.Length);
            m_audioSource.PlayOneShot(m_laserSounds[m_laserIndex]);

        }
    }
}
