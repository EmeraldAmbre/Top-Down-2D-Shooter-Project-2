using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAdapt : MonoBehaviour
{
    float m_parentScale;
    TrailRenderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_parentScale = GetComponentsInParent<Transform>()[1].localScale.x;
        m_renderer = GetComponent<TrailRenderer>();
        Debug.Log(GetComponentsInParent<Transform>()[1].gameObject.name + m_parentScale);
        m_renderer.widthMultiplier = m_parentScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
