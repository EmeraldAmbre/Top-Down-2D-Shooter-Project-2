using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    [SerializeField] private TransitionSettings m_transitionSettings;

    [SerializeField] private float m_transitionDelay;

    [SerializeField] private string m_sceneToLoadName;
    public void StartGame() {
        TransitionManager.Instance().Transition(m_sceneToLoadName, m_transitionSettings, m_transitionDelay);
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) StartGame();
    }
}
