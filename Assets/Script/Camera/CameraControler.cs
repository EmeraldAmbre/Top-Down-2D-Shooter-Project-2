using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private Vector3   m_offset = new(0, 2, -10);

    void FixedUpdate() {
        Vector3 desiredPosition = m_playerTransform.position + m_offset;
        transform.position = desiredPosition;
    }
}
