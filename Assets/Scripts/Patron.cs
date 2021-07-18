using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private Obstacles _Obstacles;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out _Obstacles))
        {
            _Obstacles.Damage();
            _animator.SetBool("Boom",true);
            _rigidbody.velocity = Vector2.zero;
            Destroy(this.gameObject,0.15f);
        }
        if (other.gameObject.tag == "EndPosition")
        {
            Destroy(this.gameObject);
        }
    }
}
