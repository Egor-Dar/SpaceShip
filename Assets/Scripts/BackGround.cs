using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class BackGround : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] float tileSize;
    private Vector3 initialPosition;
    float startTime;
    void Start()
    {
        initialPosition = base.transform.position;
        startTime = Time.time;
    }
    void Update()
    {
        transform.position = transform.position - Vector3.left * scrollSpeed * Time.deltaTime;
        //transform.position = new Vector3((Time.time - startTime) * scrollSpeed, transform.position.y, transform.position.z);
        if (transform.position.x <= tileSize)
        {
            Debug.LogWarning("WTF");
            startTime = Time.time;
            float result = transform.position.x - tileSize;
            transform.position = new Vector3(result, transform.position.y, transform.position.z);
        }
    }

}
