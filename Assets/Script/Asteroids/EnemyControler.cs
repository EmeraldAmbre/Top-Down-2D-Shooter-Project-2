using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour {

    [SerializeField] private Vector3 m_directionPoint;
    [SerializeField] private Vector3 m_minSize;
    [SerializeField] private float[] m_targetCenter = new float[2];
    [SerializeField] private float   m_targetRadius;
    [SerializeField] private float   m_speed = 2.5f;

    private void Start() {
        Vector3 center = new Vector3(m_targetCenter[0], m_targetCenter[1], 0);
        m_directionPoint = GetRandomPointOnCircle(center, m_targetRadius);
    }

    void Update() {
        Vector3 direction = m_directionPoint - transform.position;
        direction.Normalize();
        transform.position += direction * m_speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Missile")) {
            StartCoroutine(Death(0.05f));
        }
    }

    private Vector3 GetRandomPointOnCircle(Vector2 center, float radius) {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * radius + center.x;
        float y = Mathf.Sin(angle) * radius + center.y;
        return new Vector3(x, y, 0);
    }

    private IEnumerator Death(float time) {
        Vector3 newSize = transform.localScale * 0.5f;
        if (newSize.magnitude > m_minSize.magnitude)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject child = Instantiate(gameObject, transform.position, transform.rotation);
                child.transform.localScale = newSize;
            }
        }
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
