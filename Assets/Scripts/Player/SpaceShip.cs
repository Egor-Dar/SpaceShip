using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Actions))]
public class SpaceShip : MonoBehaviour
{
    [SerializeField]Actions _actions;
    public Transform _Ship;
    
    void Start()
    {
        _Ship = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        _actions.RunHor();
        _actions.RunVert();
        _actions.Attack();
    }
}
