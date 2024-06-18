using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    [SerializeField] Image m_lifeBar;
    [SerializeField] Image m_lifeHeld;
    [SerializeField] float m_lifeCount;
    float m_lifeLost;
    // Start is called before the first frame update
    void Start()
    {
        m_lifeLost = 1/4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetlifeDown();
        }
    }

     void GetlifeDown()
    {

        m_lifeBar.fillAmount = m_lifeBar.fillAmount - (1 / m_lifeCount);
        Debug.Log("lifebar fill amount: " + ( (1 / m_lifeCount)));
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
