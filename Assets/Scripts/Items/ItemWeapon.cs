using UnityEngine;
using Weapon;

public class ItemWeapon : MonoBehaviour
{
    [SerializeField] private DataWeapon _dataWeapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) other.GetComponent<PlayerLife>().EquipWeapon(_dataWeapon);
    }
}
