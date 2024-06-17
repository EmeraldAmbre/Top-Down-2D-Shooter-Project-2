using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject m_missilePrefab;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            Quaternion fireRotation = transform.rotation;
            Vector3 firePosition = transform.position;
            Instantiate(m_missilePrefab, firePosition, fireRotation);
        }
    }
}
