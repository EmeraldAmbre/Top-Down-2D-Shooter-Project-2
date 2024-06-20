using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Melting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MeltingSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MeltingSprite()
    {
        float timeElapsed = 0;
        float lerpDuration = 10;
        Material dissolveMaterial = GetComponent<SpriteRenderer>().material;
        int dissolveAmount = Shader.PropertyToID("_Vertical_Dissolve");
        Debug.Log(dissolveAmount);
        float dissolveLerp;

        while (timeElapsed < lerpDuration)
        {
            dissolveLerp = Mathf.Lerp(1.1f, 0, timeElapsed / lerpDuration);
            dissolveMaterial.SetFloat(dissolveAmount, dissolveLerp);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.DOScale(0.1f, 0.2f).SetEase(Ease.Linear);
        Destroy(gameObject, 0.2f);
    }
}
