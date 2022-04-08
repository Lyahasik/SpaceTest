using System.Collections;
using UnityEngine;

public class PlayerWeaponQueue : PlayerWeapon
{
    private const float DELAY_QUEUE = 0.05f;
    private const int COUNT_SHOT = 3;

    private float _nextTimeShot;

    protected override void Attack()
    {
        if (_nextTimeShot < Time.time)
        {
            _nextTimeShot = Time.time + _dataWeapon.Delay;
            
            StartCoroutine(Shot());
        }
    }

    private IEnumerator Shot()
    {
        for (int i = 0; i < COUNT_SHOT; i++)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x + transform.localScale.x * 0.5f + _dataWeapon.PrefabCartrige.transform.localScale.x * 0.5f,
                transform.position.y,
                transform.position.z);
            
            GameObject cartridge = Instantiate(
                _dataWeapon.PrefabCartrige,
                spawnPosition,
                transform.rotation);

            cartridge.GetComponent<ICartridge>().Init(_dataWeapon.Damage);
            
            yield return new WaitForSeconds(DELAY_QUEUE);
        }
    }
}
