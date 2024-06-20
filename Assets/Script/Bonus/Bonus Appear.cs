
using UnityEngine;
using DG.Tweening;

public class BonusAppear : MonoBehaviour
{

    AudioSource m_AudioSource;
    [SerializeField] AudioClip m_Clip;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutElastic);
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_AudioSource.PlayOneShot(m_Clip);
    }

}
