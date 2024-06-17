using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour {

    private GameObject m_player;

    [SerializeField] private float m_speed = 1.5f;

    private void Start() { m_player = GameObject.Find("Player"); }

    void Update() {
        Vector3 direction = m_player.GetComponent<Transform>().position - transform.position;
        direction.Normalize();
        transform.position += direction * m_speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Missile")) { Destroy(gameObject); }
    }
}
