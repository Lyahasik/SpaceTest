using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _windowGameOver;
    
    private int _scoreValue;
    [SerializeField] private Text _finalScore;
    
    void OnEnable()
    {
        GameEventManager.OnChangeScore += ChangeScore;
        GameEventManager.OnGameOver += GameOver;
    }
    
    void ChangeScore(int value)
    {
        _scoreValue += value;
    }

    void GameOver()
    {
        _windowGameOver.SetActive(true);
        _finalScore.text = "Score: " + _scoreValue;
    }
}
