using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarValue : MonoBehaviour
{
    private Image _image;
    
    private int _hpValue = 100;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    void OnEnable()
    {
        GameEventManager.OnChangeHealth += ChangeHealth;
    }

    void ChangeHealth(int value)
    {
        _hpValue = Mathf.Clamp(_hpValue + value, 0, 100);

        _image.fillAmount = _hpValue * 0.01f;

        if (_hpValue == 0) GameEventManager.SendKillPlayer();
    }
}
