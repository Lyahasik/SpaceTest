using UnityEngine;
using UnityEngine.UI;

public class HealthBarValue : MonoBehaviour
{
    private Image _image;

    private DataShip _dataShip;
    private int _currentHealth;

    void OnEnable()
    {
        GameEventManager.OnUploadDataUI += UploadData;
        GameEventManager.OnChangeHealth += ChangeHealth;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    void UploadData(DataShip value)
    {
        _dataShip = value;
        _currentHealth = _dataShip.MaxHealth;
    }

    void ChangeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _dataShip.MaxHealth);

        _image.fillAmount = _currentHealth * 0.01f;
    }
}
