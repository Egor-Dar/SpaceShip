using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Actions : MonoBehaviour
{
    [SerializeField] SpaceShip _spaceShip;
    [SerializeField] Buttons _buttons;

    #region Vector2Speeds
    
    //В этом регионе содержатся максимальные и минимальные параметры корабля такие как скорость.
    public float _VertSpeed = 0.1f;
    static private readonly float _MaxVertical = 6.14f;
    static private readonly float _MinVertical = -6.14f;

    static private float _newHorSpeed;
    public float _HorSpeed;
    static private readonly float _MaxHorizontalSpeed = 0.5f;
    static private readonly float _MinHorizontalSpeed = 0.05f;
    
    #endregion

    #region SaveValue

    //В этот регион будут записыватся значения которые нужно сохранить.
    

    #endregion
    
    [Space]
    [Header("Обьекты для создания/отключения")]
    public GameObject _Patron;
    public GameObject _SpawnPatron;
    public GameObject _SpawnPatron2;
    public GameObject _CanvasDie;
    public GameObject _CanvasPause;
    public GameObject _CanvasPlay;
    [Space]
    [Header("Анимация")]
    public Animator _Animator;

    void Start()
    {
        _buttons.CheckPause.AddListener(OnPause);
        _buttons.StartPause.AddListener(PauseStart);
        
        //Корабль стартует с минимальной скорости.
        _newHorSpeed = _MinHorizontalSpeed;
        _HorSpeed = _newHorSpeed;

        //В данном регионе содержатся канвасы которые будут использоватся в течении всей игры.
        #region Canvas

        _CanvasDie.SetActive(false);
        _CanvasPause.SetActive(false);
        _CanvasPlay.SetActive(true);

        #endregion

        Time.timeScale = 1;
    }

    //Данный регион содержит основные методы на которых базируется игра.
    //Методы запрещено изменять без причин или удалять.
    #region Base
    
    public void RunVert()
    {
        if (_buttons.isPause == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (_spaceShip._Ship.transform.position.y >= _MaxVertical)
                {
                    _Animator.SetBool("Up", false);
                    _VertSpeed = 0f;
                }
                else
                {
                    _Animator.SetBool("Up", true);
                    _VertSpeed = 0.1f;
                    _spaceShip._Ship.Translate(0, _VertSpeed, 0);
                }
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                _Animator.SetBool("Up", false);
                _VertSpeed = 0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (_spaceShip._Ship.transform.position.y <= _MinVertical)
                {
                    _Animator.SetBool("Down", false);
                    _VertSpeed = 0f;
                }
                else
                {
                    _Animator.SetBool("Down", true);
                    _VertSpeed = -0.1f;
                    _spaceShip._Ship.Translate(0, _VertSpeed, 0);
                }
            }

            else if (Input.GetKeyUp(KeyCode.S))
            {
                _Animator.SetBool("Down", false);
                _VertSpeed = 0;
            }
        }
        else
        {
            _VertSpeed = 0;
        }
    }
    public void RunHor()
    {
        if (_buttons.isPause == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (_HorSpeed <= _MinHorizontalSpeed)
                {
                    _HorSpeed = _MinHorizontalSpeed;
                }
                else
                {
                    _HorSpeed -= 0.001f;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (_HorSpeed >= _MaxHorizontalSpeed)
                {
                    _HorSpeed = _MaxHorizontalSpeed;
                }
                else
                {
                    _HorSpeed += 0.001f;
                }
            }
        }
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _buttons.isPause == false)
        {
            GameObject b = Instantiate(_Patron, _SpawnPatron.transform.position, _SpawnPatron.transform.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && _buttons.isPause == false)
        {
            GameObject a = Instantiate(_Patron, _SpawnPatron2.transform.position, _SpawnPatron2.transform.rotation);
            a.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0.2f);
        }
    }
    public void Die()
    {
        _HorSpeed = 0;
        _CanvasDie.SetActive(true);
        Time.timeScale = 0;
        Destroy(this.gameObject);
    }

    public void OnPause()
    {
        Debug.Log(_newHorSpeed);
        _HorSpeed = _newHorSpeed;
    }
    public void PauseStart()
    {
        _newHorSpeed = _HorSpeed;
        _HorSpeed = 0;
    }
    #endregion
    
    //Данный регион содержит дополнительные методы которые дополняют игровой процесс.
    //Методы запрещено изменять без причин или удалять.

    #region Additional methods

    #endregion
}
