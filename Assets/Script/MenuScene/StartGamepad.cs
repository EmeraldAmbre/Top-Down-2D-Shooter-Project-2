using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamepad : MonoBehaviour {

    [SerializeField] private TransitionSettings m_transitionSettings;

    [SerializeField] private float m_transitionDelay;

    [SerializeField] private string m_sceneToLoadName;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) TransitionManager.Instance().Transition(m_sceneToLoadName, m_transitionSettings, m_transitionDelay);
    }
}
