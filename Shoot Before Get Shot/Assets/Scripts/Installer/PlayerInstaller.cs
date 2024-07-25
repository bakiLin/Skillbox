using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private HealthPlayer healthPlayer;

    [SerializeField]
    private ShootPlayer shootPlayer;

    [SerializeField]
    private MovementPlayer movementPlayer;

    [SerializeField]
    private ShootProgress shootProgress;

    public override void InstallBindings()
    {
        Container.Bind<HealthPlayer>().FromInstance(healthPlayer).AsSingle().NonLazy();

        Container.Bind<ShootPlayer>().FromInstance(shootPlayer).AsSingle().NonLazy();

        Container.Bind<MovementPlayer>().FromInstance(movementPlayer).AsSingle().NonLazy();

        Container.Bind<ShootProgress>().FromInstance(shootProgress).AsSingle().NonLazy();
    }
}