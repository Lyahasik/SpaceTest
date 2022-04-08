using System;
using UnityEngine;

public class PlayerWeaponLaser : PlayerWeapon
{
    private GameObject _cartridge;

    private void OnDisable()
    {
        Destroy(_cartridge);
    }
    
    protected override void Attack()
    {
        Shot();
    }

    private void Shot()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x + transform.localScale.x * 0.5f + _dataWeapon.PrefabCartrige.transform.localScale.x * 0.5f, 
            transform.position.y,
            transform.position.z);
        
        _cartridge = Instantiate(
            _dataWeapon.PrefabCartrige,
            spawnPosition,
            transform.rotation,
            transform);

        _cartridge.GetComponent<ICartridge>().Init(_dataWeapon.Damage);
    }
}
