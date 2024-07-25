using UnityEngine;
using Zenject;

public class ButtonInstaller : MonoInstaller
{
    [SerializeField]
    private Shading fadeImage;

    public override void InstallBindings()
    {
        Container.Bind<Shading>()
            .FromInstance(fadeImage)
            .AsSingle()
            .NonLazy();
    }
}