using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerLife _player;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerLife>().FromInstance(_player).AsSingle();
    }
}