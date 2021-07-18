using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] public Actions _Actions;
    public float _Life;
    public GameObject _Sprite;
    private Animator _Animator;

    void Start()
    {
        _Animator = _Sprite.GetComponent<Animator>();
    }

    void Update()
    {
        this.gameObject.transform.Translate(-_Actions._HorSpeed, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out _Actions))
        {
            _Actions.Die();
            //Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "EndPosition")
        {
            Destroy(this.gameObject);
        }
    }


    public void Damage()
    {
        _Life--;
        if (_Life == 0)
        {
            _Animator.SetBool("Die", true);
            StartCoroutine(DieTime());

        }
    }
    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(0.31f);
        Destroy(this.gameObject);
    }

}
