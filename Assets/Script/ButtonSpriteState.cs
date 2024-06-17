using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSpriteState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite highlightedSprite;
    [SerializeField] Sprite pushedSprite;
    Button thisbutton;
    Image image;
    [SerializeField]
    GameObject particle;

    

    // Start is called before the first frame update
    void Start()
    {
        thisbutton = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        image.sprite = idleSprite;

    }


    void SpriteToHighlighted()
    {
        image.sprite = highlightedSprite;
        particle.SetActive(true);
    }

    void SpriteToIdle()
    {
        image.sprite = idleSprite;
        particle.SetActive(false);
    }

    void SpriteToPushed()
    {
        image.sprite = pushedSprite;
        particle.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SpriteToHighlighted();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SpriteToIdle();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SpriteToPushed();
        //StartCoroutine (SpriteReturnToNormal());
    }

    /*IEnumerator SpriteReturnToNormal()
    {
        yield return new WaitForSeconds(0.2f);
        SpriteToIdle();
    }*/
}
