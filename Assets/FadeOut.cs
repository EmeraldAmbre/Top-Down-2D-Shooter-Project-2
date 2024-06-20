using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeOut : MonoBehaviour
{
    private float m_impactLightIntensity;
    Light2D m_explosionLight;
    [SerializeField] float m_lerpDuration;

    // Start is called before the first frame update
    void Start()
    {
        m_explosionLight = GetComponent<Light2D>();
        StartCoroutine(ExplosionFadeOut());

    }


    IEnumerator ExplosionFadeOut()
    {
        float timeElapsed = 0;
        while (timeElapsed < m_lerpDuration)
        {
            m_impactLightIntensity = Mathf.Lerp(m_explosionLight.intensity, 0, timeElapsed / m_lerpDuration);
            m_explosionLight.intensity = m_impactLightIntensity;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
