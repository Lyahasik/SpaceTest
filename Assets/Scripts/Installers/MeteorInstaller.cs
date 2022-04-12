using UnityEngine;
using Zenject;

public class MeteorInstaller : MonoInstaller
{
    [SerializeField] private DataMeteor[] _dataMeteors;
    
    public override void InstallBindings()
    {
        Container.Bind<DataMeteor[]>().FromInstance(_dataMeteors);
    }
}