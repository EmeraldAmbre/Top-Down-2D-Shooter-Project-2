using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BonusControler : MonoBehaviour {

    [SerializeField] private int m_bonusPoints = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7) {

            GameController._playerScore += m_bonusPoints;
            BackGroundRandomiser._nbBonusOnScreen -= 1;

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Light2D>().enabled = false;

            Destroy(gameObject, 10f);
        }
    }
}
