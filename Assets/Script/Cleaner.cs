using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] private float x_range;
    [SerializeField] private float y_range;
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > x_range || Mathf.Abs(transform.position.y) > y_range)
        {
            Destroy(gameObject);
        }
    }
}
