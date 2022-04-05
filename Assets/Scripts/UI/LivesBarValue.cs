using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesBarValue : MonoBehaviour
{
    private Text _text;

    private int _livesValue = 3;

    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "X" + _livesValue;
    }

    void OnEnable()
    {
        GameEventManager.OnChangeLives += ChangeLives;
    }
    
    void ChangeLives(int value)
    {
        _livesValue = Mathf.Clamp(_livesValue + value, 0, 3);

        _text.text = "X" + _livesValue;
        
        if (_livesValue == 0) GameEventManager.SendGameOver();
    }
}
