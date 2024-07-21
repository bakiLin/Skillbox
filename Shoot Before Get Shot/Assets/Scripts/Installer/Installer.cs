using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField]
    private HealthPlayer healthPlayer;

    public override void InstallBindings()
    {
        Container.Bind<HealthPlayer>()
            .FromInstance(healthPlayer)
            .AsSingle()
            .NonLazy();
    }
}