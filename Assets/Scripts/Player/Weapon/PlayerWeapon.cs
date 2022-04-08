using UnityEngine;
using Weapon;

public abstract class PlayerWeapon : MonoBehaviour
{
    protected DataWeapon _dataWeapon;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    public void Init(DataWeapon dataWeapon)
    {
        _dataWeapon = dataWeapon;
    }
    
    protected abstract void Attack();
}
