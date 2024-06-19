using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyControler : MonoBehaviour {

    [SerializeField] private Vector3 m_directionPoint;
    [SerializeField] private Vector3 m_minSize;
    [SerializeField] private float[] m_targetCenter = new float[2];
    [SerializeField] private float   m_targetRadius;
    [SerializeField] private float   m_speed = 2.5f;
    AudioSource m_audioSource;
    [SerializeField] private AudioClip[] m_hitSounds;
    int m_hitSoundsIndex;
    [SerializeField] Sprite[] m_asteroidsSprites;
    int m_spritesIndex;
    SpriteRenderer m_spriteRenderer;

    [SerializeField] Light2D m_impactLight;
    [SerializeField] int m_lifePoints;
    [SerializeField] GameObject m_hitParticles;

    private void Start() 
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spritesIndex = Random.Range(0, m_asteroidsSprites.Length);
        m_spriteRenderer.sprite = m_asteroidsSprites[m_spritesIndex];
        Vector3 center = new Vector3(m_targetCenter[0], m_targetCenter[1], 0);
        m_directionPoint = GetRandomPointOnCircle(center, m_targetRadius);
        Vector3 direction = m_directionPoint - transform.position;
        direction.Normalize();       
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * m_speed, ForceMode2D.Impulse);
        m_audioSource = GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) 
        {
            m_impactLight.transform.position = collision.GetContact(0).point;
            m_hitParticles.transform.position = collision.GetContact(0).point;
            m_hitParticles.SetActive(true);
            m_impactLight.enabled = true;
            if (m_lifePoints <= 0)
            {
            StartCoroutine(Death(0.05f));
            }
            m_hitSoundsIndex = Random.Range(0, m_hitSounds.Length);
            m_audioSource.PlayOneShot(m_hitSounds[m_hitSoundsIndex]);
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

        Destroy(gameObject,0.5f);
    }
}
