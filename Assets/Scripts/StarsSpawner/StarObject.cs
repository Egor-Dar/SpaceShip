using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject : MonoBehaviour
{
    [SerializeField] public Actions _Actions;

    void Update()
    {
        transform.Translate(-_Actions._HorSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out _Actions))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("EndPosition"))
        {
            Destroy(this.gameObject);
        }
    }
}