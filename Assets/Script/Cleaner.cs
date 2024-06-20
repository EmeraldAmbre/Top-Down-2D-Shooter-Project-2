using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

    [SerializeField] private float x_range;
    [SerializeField] private float y_range;
    [SerializeField] private float m_targetRadius;
    [SerializeField] private float[] m_targetCenter = new float[2];
    
    private Vector3 m_directionPoint;

    void Update()
    {
        if (Mathf.Abs(transform.position.x) > x_range || Mathf.Abs(transform.position.y) > y_range) {

            // Keeping Asteroids on screen, destroying shots
            if (gameObject.layer == 6) {

                // Random impulse in a random direction
                Vector3 center = new Vector3(m_targetCenter[0], m_targetCenter[1], 0);
                m_directionPoint = GetRandomPointOnCircle(center, m_targetRadius);
                Vector3 direction = m_directionPoint - transform.position;
                direction.Normalize();
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 0.05f, ForceMode2D.Impulse);
            }

            else {
                Destroy(gameObject);
            }
        }
    }

    private Vector3 GetRandomPointOnCircle(Vector2 center, float radius) {

        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * radius + center.x;
        float y = Mathf.Sin(angle) * radius + center.y;
        return new Vector3(x, y, 0);
    }

}
