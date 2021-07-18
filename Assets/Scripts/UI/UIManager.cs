using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text score;
    private int _Score;

    public int Score {
        get
        {
            return _Score;
        }

        set
        {
            _Score = value;
        }
        
    }
    
    public void AddScore(int valuerScore)
    {
        score.text = _Score.ToString();
    }
}
