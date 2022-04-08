using UnityEngine;
using UnityEngine.UI;

public class LivesBarValue : MonoBehaviour
{
    private Text _text;

    private DataShip _dataShip;
    private int _currentLives;

    void OnEnable()
    {
        GameEventManager.OnUploadDataUI += UploadData;
        GameEventManager.OnChangeLives += ChangeLives;
    }

    void UploadData(DataShip value)
    {
        _dataShip = value;
        _currentLives = _dataShip.MaxLives;
        
        _text = GetComponent<Text>();
        _text.text = "X" + _currentLives;
    }
    
    void ChangeLives(int value)
    {
        _currentLives = Mathf.Clamp(_currentLives + value, 0, _dataShip.MaxLives);

        _text.text = "X" + _currentLives;
    }
}
