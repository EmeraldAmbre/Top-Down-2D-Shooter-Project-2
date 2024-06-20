using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Melting : MonoBehaviour
{

    AudioSource m_AudioSource;
    [SerializeField] AudioClip m_Clip;
    CircleCollider2D m_CircleCollider;
    SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MeltingSprite());
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_CircleCollider = gameObject.GetComponent<CircleCollider2D>();
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    

    public IEnumerator MeltingSprite()
    {
        float timeElapsed = 0;
        float lerpDuration = 6;
        Material dissolveMaterial = GetComponent<SpriteRenderer>().material;
        int dissolveAmount = Shader.PropertyToID("_Vertical_Dissolve");
        Debug.Log(dissolveAmount);
        float dissolveLerp;

        while (timeElapsed < lerpDuration)
        {
            dissolveLerp = Mathf.Lerp(1.1f, 0.4f, timeElapsed / lerpDuration);
            dissolveMaterial.SetFloat(dissolveAmount, dissolveLerp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.DOScale(0.1f, 0.2f).SetEase(Ease.Linear);
        yield return 0.2f;
        m_SpriteRenderer.enabled = false;
        m_CircleCollider.enabled = false;
        m_AudioSource.PlayOneShot(m_Clip);
        Destroy(gameObject, 1f);
    }
}
