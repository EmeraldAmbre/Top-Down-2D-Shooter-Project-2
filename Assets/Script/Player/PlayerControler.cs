using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float   m_moveSpeed = 5f;
    [SerializeField] private float   m_rotationSpeed = 200f;
                     private Vector2 m_movement;
                     private Rigidbody2D m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update() {
        float rotationInput = Input.GetAxis("Horizontal");
        float rotation = rotationInput * m_rotationSpeed * Time.deltaTime;
        m_movement.x = 0;
        m_movement.y = Input.GetAxis("Vertical");
        if (rotationInput != 0) { transform.Rotate(Vector3.back, rotation); }
    }
    void FixedUpdate()
    {
        Vector2 forward = transform.up;
        m_rigidbody.MovePosition(m_rigidbody.position + forward * m_movement.y * m_moveSpeed * Time.fixedDeltaTime);
    }
}
