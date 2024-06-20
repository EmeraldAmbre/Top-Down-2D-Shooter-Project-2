using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BonusAppear : MonoBehaviour
{

    AudioSource m_AudioSource;
    [SerializeField] AudioClip m_Clip;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        //m_AudioSource.PlayOneShot(m_Clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
