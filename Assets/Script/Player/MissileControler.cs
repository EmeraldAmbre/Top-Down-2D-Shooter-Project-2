using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControler : MonoBehaviour {

    [SerializeField] private float m_bulletLifeTime = 3.0f;
    [SerializeField] private float m_bulletSpeed = 10.0f;

    private bool m_isColliderActivated;
    private Vector3 m_bulletDirection;
    private CircleCollider2D m_collider;

    void Start() {
        m_collider = GetComponent<CircleCollider2D>();
        m_collider.enabled = false;
        m_isColliderActivated = false;
        m_bulletDirection = transform.up * 1;

        StartCoroutine(ColliderDelay(0.15f));
        StartCoroutine(DestroyAfterTime(m_bulletLifeTime));
    }
    void Update() {
        if (m_isColliderActivated) { m_collider.enabled = true; }
        transform.position += m_bulletDirection * m_bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private IEnumerator ColliderDelay(float time)
    {
        yield return new WaitForSeconds(time);
        m_isColliderActivated = true;
    }
}
