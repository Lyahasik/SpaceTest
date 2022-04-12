using UnityEngine;
using Weapon;
using Zenject;

public class PlayerLife : MonoBehaviour
{
    [Inject] private DataShip _dataShip;
    [Inject] private DataWeapon _dataWeapon;

    private PlayerWeapon _weapon;

    private int _currentHealth;
    private int _currentLives;

    void OnEnable()
    {
        GameEventManager.OnChangeHealth += ChangeHealth;
        GameEventManager.OnChangeLives += ChangeLives;
        GameEventManager.OnKillPlayer += PlayerKill;
    }

    private void Start()
    {
        _currentHealth = _dataShip.MaxHealth;
        _currentLives = _dataShip.MaxLives;
        
        GameEventManager.SendUploadDataUI(_dataShip);
        EquipWeapon(_dataWeapon);
    }

    private void Update()
    {
        if (GameplayController.IsPlaying)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Time.deltaTime * _dataShip.Speed;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + move.x, -8.0f, 0),
                Mathf.Clamp(transform.position.y + move.y, -4.0f, 4.0f),
                0.0f);
        }
    }

    public void EquipWeapon(DataWeapon dataWeapon)
    {
        if (_dataWeapon == dataWeapon && _weapon) return;
            
        _dataWeapon = dataWeapon;
        Destroy(_weapon);
        
        switch (dataWeapon.TypeAttack)
        {
            case TypeAttack.Queue:
                _weapon = gameObject.AddComponent<PlayerWeaponQueue>();
                _weapon.Init(dataWeapon);
                break;
            case TypeAttack.Laser:
                _weapon = gameObject.AddComponent<PlayerWeaponLaser>();
                _weapon.Init(dataWeapon);
                break;
        }
    }

    void ChangeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, 100);

        if (_currentHealth == 0) GameEventManager.SendKillPlayer();
    }
    
    void ChangeLives(int value)
    {
        _currentLives = Mathf.Clamp(_currentLives + value, 0, _dataShip.MaxLives);
        
        if (_currentLives == 0) GameEventManager.SendGameOver();
    }

    void PlayerKill()
    {
        GameEventManager.SendChangeHealth(_dataShip.MaxHealth);
        GameEventManager.SendChangeLives(-1);
    }
}
