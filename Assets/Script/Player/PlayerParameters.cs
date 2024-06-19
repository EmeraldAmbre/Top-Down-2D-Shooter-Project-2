using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour {

    [SerializeField] private int       m_maxHealth = 3;
    [SerializeField] private float     m_invincibilityDuration = 2.5f;
    [SerializeField] private LifeBar   m_lifeBar;
    [SerializeField] private AudioClip m_bumpSound;

    private int   m_currentHealth;
    private bool  m_isInvincible;
    private bool  m_isSpriteActive;
    private float m_invincibilityTimer;
    private AudioSource m_audioSource;

    void Start () {
        m_isInvincible = false;
        m_isSpriteActive = true;
        m_currentHealth = m_maxHealth;
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        InvincibilityFrame();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            if (!m_isInvincible) {
                m_currentHealth -= 1;
                m_audioSource.PlayOneShot(m_bumpSound);
                m_lifeBar.GetlifeDown(m_maxHealth);
                m_isInvincible = true;
                m_invincibilityTimer = m_invincibilityDuration;
            }
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (!m_isInvincible) {
                m_currentHealth -= 1;
                m_audioSource.PlayOneShot(m_bumpSound);
                m_lifeBar.GetlifeDown(m_maxHealth);
                m_isInvincible = true;
                m_invincibilityTimer = m_invincibilityDuration;
            }
        }
    } */

    private void InvincibilityFrame() {
        if (m_isInvincible) {
            if (m_isSpriteActive) {
                GetComponent<SpriteRenderer>().enabled = false;
                m_isSpriteActive = false;
            }
            else {
                GetComponent<SpriteRenderer>().enabled = true;
                m_isSpriteActive = true;
            }

            m_invincibilityTimer -= Time.deltaTime;

            if (m_invincibilityTimer < 0) {
                m_isInvincible = false;
                if (!m_isSpriteActive) {
                    GetComponent<SpriteRenderer>().enabled = true;
                    m_isSpriteActive = true;
                }
            }
        }
    }

    private void Death() {

    }
}
