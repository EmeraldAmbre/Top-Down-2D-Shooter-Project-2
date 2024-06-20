using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerParameters : MonoBehaviour {

    [SerializeField] private int       m_maxHealth = 3;
    [SerializeField] private float     m_invincibilityDuration = 2.5f;
    [SerializeField] private LifeBar   m_lifeBar;
    [SerializeField] private AudioClip m_bumpSound;
    [SerializeField] private Canvas    m_gameOverCanvas;
    [SerializeField] private TextMeshProUGUI m_gameOverText;

    private int   m_currentHealth;
    private bool  m_isInvincible;
    private bool  m_isSpriteActive;
    private float m_invincibilityTimer;
    private AudioSource m_audioSource;

    [SerializeField] private GameObject m_mainCamera;
    // [SerializeField] private GameObject m_hitParticlesInstance;
    // [SerializeField] private GameObject m_hitParticles;

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
                StartCoroutine(Shake());
                m_audioSource.PlayOneShot(m_bumpSound);
                m_lifeBar.GetlifeDown(m_maxHealth);
                m_isInvincible = true;
                m_invincibilityTimer = m_invincibilityDuration;
                //m_hitParticlesInstance = Instantiate(m_hitParticles, gameObject.transform);
                //m_hitParticlesInstance.transform.position = collider.transform.position;
                //m_hitParticlesInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, collider.transform.up);
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
        // Desactivate player components
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        // Activate Game Over Canvas
        m_gameOverCanvas.gameObject.SetActive(false);
        m_gameOverText.text = "Current score : " + GameController._playerScore.ToString();
    }

    public IEnumerator Shake()
    {
        float duration = 0.2f;
        float magnitude = 0.1f;
        Vector3 originalPos = m_mainCamera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            m_mainCamera.transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        m_mainCamera.transform.localPosition = originalPos;
    }
}
