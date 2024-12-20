using System.Collections;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField] private bool m_isOutByX;
    [SerializeField] private bool m_isOutByY;
    [SerializeField] private bool m_isMain;
    [SerializeField] private bool m_isTeleporting;
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private float m_rotationSpeed = 200f;
    [SerializeField] private GameObject[] m_clones = new GameObject[8];

    // Thrust particles for impulse of the spaceship
    [SerializeField] private GameObject  m_thrustParticles;
    [SerializeField] private GameObject  m_thrustSprites;
    [SerializeField] private AudioSource m_thrustAudioSource;
    [SerializeField] private AudioClip   m_thrustSound;
    [SerializeField] private float       m_thrustVolume;

    private Vector2 m_movement;
    private Rigidbody2D m_rigidbody;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_isTeleporting = false;
    }

    void Update() {

        // Inputs
        float rotationInput = Input.GetAxis("Horizontal");

        // Movement
        m_movement.x = 0; m_movement.y = Input.GetAxis("Vertical");

        // Rotation
        if (rotationInput != 0) { transform.Rotate(Vector3.back, rotationInput * m_rotationSpeed * Time.deltaTime); }

        // Activate or desactivate the thrust particles animation

        if (rotationInput != 0 || m_movement.y != 0) { ThrustAnimation(); }
        else { ThrustStop(); }

        /* if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)) {
            ThrustAnimation();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow)
                || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)) {
            ThrustStop();
        } */

        // Getting out the screen by X
        if (Mathf.Abs(transform.position.x) > 32)
        { m_isOutByX = true; }
        else
        { m_isOutByX = false; }

        // Getting out the screen by Y
        if (Mathf.Abs(transform.position.y) > 18)
        { m_isOutByY = true; }
        else
        { m_isOutByY = false; }

        // Teleporting by X
        if (m_isOutByX && m_isMain) {
            if (!m_isTeleporting) {

                m_isTeleporting = true;
                Vector3 newPosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
                transform.position = newPosition;

                // Teleporting the clones
                Vector3 offset_1 = new(-64, 36, 0);
                m_clones[0].transform.position = newPosition + offset_1;
                Vector3 offset_2 = new(0, 36, 0);
                m_clones[1].transform.position = newPosition + offset_2;
                Vector3 offset_3 = new(64, 36, 0);
                m_clones[2].transform.position = newPosition + offset_3;
                Vector3 offset_4 = new(64, 0, 0);
                m_clones[3].transform.position = newPosition + offset_4;
                Vector3 offset_5 = new(64, -36, 0);
                m_clones[4].transform.position = newPosition + offset_5;
                Vector3 offset_6 = new(0, -36, 0);
                m_clones[5].transform.position = newPosition + offset_6;
                Vector3 offset_7 = new(-64, -36, 0);
                m_clones[6].transform.position = newPosition + offset_7;
                Vector3 offset_8 = new(-64, 0, 0);
                m_clones[7].transform.position = newPosition + offset_8;

                StartCoroutine(TeleporterDelay(0.1f));
            }
        }

        // Teleporting by Y
        if (m_isOutByY && m_isMain) {
            if (!m_isTeleporting) {
                m_isTeleporting = true;
                Vector3 newPosition = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
                transform.position = newPosition;

                // Teleporting the clones
                Vector3 offset_1 = new(-64, 36, 0);
                m_clones[0].transform.position = newPosition + offset_1;
                Vector3 offset_2 = new(0, 36, 0);
                m_clones[1].transform.position = newPosition + offset_2;
                Vector3 offset_3 = new(64, 36, 0);
                m_clones[2].transform.position = newPosition + offset_3;
                Vector3 offset_4 = new(64, 0, 0);
                m_clones[3].transform.position = newPosition + offset_4;
                Vector3 offset_5 = new(64, -36, 0);
                m_clones[4].transform.position = newPosition + offset_5;
                Vector3 offset_6 = new(0, -36, 0);
                m_clones[5].transform.position = newPosition + offset_6;
                Vector3 offset_7 = new(-64, -36, 0);
                m_clones[6].transform.position = newPosition + offset_7;
                Vector3 offset_8 = new(-64, 0, 0);
                m_clones[7].transform.position = newPosition + offset_8;

                StartCoroutine(TeleporterDelay(0.1f));
            }
        }

        // Desactivate the clone if it's out of screen
        if ((m_isOutByX || m_isOutByY) && !m_isMain) {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 forward = transform.up;
        m_rigidbody.MovePosition(m_rigidbody.position + forward * m_movement.y * m_moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator TeleporterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        m_isTeleporting = false;
    }

    // Animating the thrust particles behind the spaceship
    void ThrustAnimation() {
        if (m_thrustParticles != null) m_thrustParticles.SetActive(true);
        if (m_thrustSprites != null) m_thrustSprites.SetActive(true);
        if (m_thrustAudioSource != null) m_thrustAudioSource.PlayOneShot(m_thrustSound, m_thrustVolume);
    }
    void ThrustStop() {
        if (m_thrustAudioSource != null) m_thrustAudioSource.Stop();
        if (m_thrustParticles != null) m_thrustParticles.SetActive(false);
        if (m_thrustSprites != null) m_thrustSprites.SetActive(false); 
    }
}
