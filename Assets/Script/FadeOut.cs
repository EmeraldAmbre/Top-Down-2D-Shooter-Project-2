using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadeOut : MonoBehaviour
{
    private float m_lightIntensity;
    Light2D m_light;
    [SerializeField] float m_lerpDuration;

    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light2D>();
        StartCoroutine(ExplosionFadeOut());

    }


    IEnumerator ExplosionFadeOut()
    {
        float timeElapsed = 0;
        while (timeElapsed < m_lerpDuration)
        {
            m_lightIntensity = Mathf.Lerp(m_light.intensity, 0, timeElapsed / m_lerpDuration);
            m_light.intensity = m_lightIntensity;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
