using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _scoreValue;
    
    private Text _text;

    void OnEnable()
    {
        GameEventManager.OnChangeScore += ChangeScore;
        GameEventManager.OnGameOver += GameOver;
    }
    
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "Score: " + _scoreValue;
    }
    
    void ChangeScore(int value)
    {
        _scoreValue += value;
        _text.text = "Score: " + _scoreValue;
    }

    void GameOver()
    {
        if (PlayerPrefs.GetInt("RecordScore") < _scoreValue) PlayerPrefs.SetInt("RecordScore", _scoreValue);
    }
}
