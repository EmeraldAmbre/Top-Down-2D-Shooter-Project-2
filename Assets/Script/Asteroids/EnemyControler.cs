using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyControler : MonoBehaviour {

    [SerializeField] private Vector3     m_directionPoint;
    [SerializeField] private Vector3     m_minSize;
    [SerializeField] private float[]     m_targetCenter = new float[2];
    [SerializeField] private float       m_targetRadius;
    [SerializeField] private float       m_speed = 2.5f;
    [SerializeField] private int         m_lifePoints;
    [SerializeField] private GameObject  m_child;
    [SerializeField] private GameObject  m_hitParticles;
    [SerializeField] private GameObject  m_hitLightObject;
    [SerializeField] private GameObject  m_explosionParticles;
    [SerializeField] private GameObject  m_explosionLightObject;
    [SerializeField] private Sprite[]    m_asteroidsSprites;
    [SerializeField] private AudioClip[] m_hitSounds;

    private GameObject m_hitLightInstance;
    private GameObject m_hitParticlesInstance;
    private float m_impactLightIntensity;

    SpriteRenderer m_spriteRenderer;
    AudioSource m_audioSource;
    int m_hitSoundsIndex;
    int m_spritesIndex;
    private GameObject m_explosionLightInstance;

    void Start() {

        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spritesIndex   = Random.Range(0, m_asteroidsSprites.Length);
        m_spriteRenderer.sprite = m_asteroidsSprites[m_spritesIndex];
        m_audioSource = GetComponent<AudioSource>();

        // Random impulse in a random direction
        Vector3 center = new Vector3(m_targetCenter[0], m_targetCenter[1], 0);
        m_directionPoint = GetRandomPointOnCircle(center, m_targetRadius);
        Vector3 direction = m_directionPoint - transform.position;
        direction.Normalize();       
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * m_speed, ForceMode2D.Impulse);

        // Set the life points according to the scale
        Vector3 scale = transform.localScale;
        Vector3 bigBro = new (2, 2, 2);
        Vector3 midBro = new (1, 1, 1);
        Vector3 lilBro = m_minSize;

        if (scale == bigBro) m_lifePoints = 3;
        else if (scale == midBro) m_lifePoints = 2;
        else if (scale == lilBro) m_lifePoints = 1;
    }

    private void Update() {

        if (!m_spriteRenderer.enabled && transform.childCount != 0) {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.layer == 8) {

            m_hitLightInstance = Instantiate(m_hitLightObject,gameObject.transform);
            m_hitLightInstance.transform.position = collider.transform.position;
            StartCoroutine(FadeOut());
            m_hitParticlesInstance = Instantiate(m_hitParticles, gameObject.transform);
            m_hitParticlesInstance.transform.position = collider.transform.position;
            m_hitParticlesInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, collider.transform.up);
            

            m_lifePoints -= 1;
            if (m_lifePoints <= 0) { StartCoroutine(Death(1.2f)); }

            m_hitSoundsIndex = Random.Range(0, m_hitSounds.Length);
            m_audioSource.PlayOneShot(m_hitSounds[m_hitSoundsIndex]);
            Destroy(collider.gameObject);
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {

            m_impactLight.transform.position = collision.GetContact(0).point;
            m_hitParticles.transform.position = collision.GetContact(0).point;
            m_hitParticles.SetActive(true);
            m_impactLight.enabled = true;

            m_lifePoints -= 1;
            if (m_lifePoints <= 0) { StartCoroutine(Death(0.05f)); }

            m_hitSoundsIndex = Random.Range(0, m_hitSounds.Length);
            m_audioSource.PlayOneShot(m_hitSounds[m_hitSoundsIndex]);
        }
    } */

    private Vector3 GetRandomPointOnCircle(Vector2 center, float radius) {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * radius + center.x;
        float y = Mathf.Sin(angle) * radius + center.y;
        return new Vector3(x, y, 0);
    }

    private IEnumerator Death(float time) {

        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        GameController._playerScore += 1;

        Vector3 bigAsteroidsScale = new (2, 2, 2);

        if (transform.localScale == bigAsteroidsScale) GameController._bigAsteroids -= 1;

        Vector3 newSize = transform.localScale * 0.5f;
        
        m_explosionLightInstance = Instantiate(m_explosionLightObject, transform.position, transform.rotation);
        StartCoroutine(FadeOut());
        Instantiate(m_explosionParticles, gameObject.transform.position, Quaternion.identity);

        if (newSize.magnitude >= m_minSize.magnitude)
        {
            for (int i = 0; i < 2; i++) {
                GameObject child = Instantiate(m_child, transform.position, transform.rotation);
                child.transform.localScale = newSize;
            }
        }

        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }

    IEnumerator FadeOut()
    {
        float timeElapsed = 0;
        float lerpDuration = 80f;
        Light2D light = m_hitLightInstance.GetComponent<Light2D>();
        while (timeElapsed < lerpDuration)
        {          
            m_impactLightIntensity = Mathf.Lerp(light.intensity,0, timeElapsed / lerpDuration);
            light.intensity = m_impactLightIntensity;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
