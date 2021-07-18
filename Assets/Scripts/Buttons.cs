using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    #region PauseElement
    private bool _isPause;
    public bool isPause
    {
        get { return _isPause; }
        set { _isPause = value; CheckPause.Invoke(); }
    }
    public UnityEvent CheckPause = new UnityEvent();
    private int _speedTime;
    public int SpeedTime
    {
        get { return _speedTime; }
        set { _speedTime = value; StartPause.Invoke(); }
    }
    public UnityEvent StartPause = new UnityEvent();

    [SerializeField] GameObject _PauseCanvas;
    [SerializeField] GameObject _PlayCanvas;
    #endregion
    public void Replay()
    {
        Time.timeScale = 1;
        isPause = false;
        SceneManager.LoadScene("Play");
    }
    public void PlayMain()
    {
        Debug.Log("StartScene");
        isPause = false;
        SceneManager.LoadScene("Play");
        Time.timeScale = 1;
    }
    public void PlayGame()
    {
        _PauseCanvas.SetActive(false);
        isPause = false;
        _PlayCanvas.SetActive(true);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        _PauseCanvas.SetActive(true);
        SpeedTime = 1;
        _isPause = true;
        _PlayCanvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("Main");
        isPause = false;
        Time.timeScale = 1;
    }
}
