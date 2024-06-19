using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackGroundRandomiser : MonoBehaviour
{
    [SerializeField] GameObject[] elements;
    int m_elementIndex;
    int m_numberOfElements;
    float m_screenWidth;
    float m_screenHeight;
    float m_scale;
    float m_xValue;
    float m_yValue;
    GameObject m_instantiatedObject;

    // Start is called before the first frame update
    void Start()
    {
        m_screenWidth = Screen.width;
        m_screenHeight = Screen.height; 
        m_numberOfElements = Random.Range(3, 6);
        for (int i = 0; i < m_numberOfElements; i++)
        {
            m_elementIndex = Random.Range(0, elements.Length);
            m_xValue = Random.Range(0, m_screenWidth);
            m_yValue = Random.Range(0, m_screenHeight);
            m_scale = Random.Range(1.5f, 6f);
            m_instantiatedObject = Instantiate(elements[m_elementIndex], Camera.main.ScreenToWorldPoint(new Vector3(m_xValue, m_yValue,10)), Quaternion.identity);
            m_instantiatedObject.transform.localScale = new Vector3 (m_scale,m_scale,1);

        }
    }
}
