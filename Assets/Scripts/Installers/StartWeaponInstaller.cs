using UnityEngine;
using Weapon;
using Zenject;

public class StartWeaponInstaller : MonoInstaller
{
    [SerializeField] private DataWeapon _dataWeapon;
    
    public override void InstallBindings()
    {
        Container.Bind<DataWeapon>().FromInstance(_dataWeapon);
    }
}