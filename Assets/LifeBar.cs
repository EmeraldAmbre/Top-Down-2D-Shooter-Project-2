using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    [SerializeField] Image m_lifeBar;
    [SerializeField] Image m_lifeHeld;
    float m_lifeCount;
    

     public void GetlifeDown(float maxHealth)
    {
        m_lifeCount = maxHealth;
        m_lifeBar.fillAmount = m_lifeBar.fillAmount - (1 / m_lifeCount);
        StartCoroutine(LifeProjection());

    }

    IEnumerator LifeProjection()
    {
        yield return new WaitForSeconds(0.5f);
        float m_lifeHeldStart = m_lifeHeld.fillAmount;
        float m_lifeHeldEnd = m_lifeHeld.fillAmount - (1 / m_lifeCount);
        float m_lifeHeldAmount;
        float timeElapsed =0;
        float lerpDuration = 1;
        while (timeElapsed < lerpDuration)
        {
            m_lifeHeldAmount = Mathf.Lerp(m_lifeHeldStart, m_lifeHeldEnd, timeElapsed / lerpDuration);
            m_lifeHeld.fillAmount = m_lifeHeldAmount;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        m_lifeHeld.fillAmount = m_lifeBar.fillAmount;
    }
}
