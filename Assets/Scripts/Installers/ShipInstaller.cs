using UnityEngine;
using Zenject;

public class ShipInstaller : MonoInstaller
{
    [SerializeField] private DataShip _dataShip;
    
    public override void InstallBindings()
    {
        Container.Bind<DataShip>().FromInstance(_dataShip);
    }
}