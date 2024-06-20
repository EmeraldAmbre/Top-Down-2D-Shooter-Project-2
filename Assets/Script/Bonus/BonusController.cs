using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BonusControler : MonoBehaviour {

    [SerializeField] private int m_bonusPoints = 10;
    AudioSource m_AudioSource;
    [SerializeField] AudioClip m_Clip;
    Melting m_MeltingScript;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_MeltingScript = GetComponent<Melting>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7) {

            GameController._playerScore += m_bonusPoints;
            BackGroundRandomiser._nbBonusOnScreen -= 1;
            m_AudioSource.PlayOneShot(m_Clip);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Light2D>().enabled = false;
            m_MeltingScript.StopAllCoroutines();
            m_MeltingScript.enabled = false;

            Destroy(gameObject, 10f);
        }
    }
}
