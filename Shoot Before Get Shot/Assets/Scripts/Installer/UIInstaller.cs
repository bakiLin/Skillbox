using UnityEngine;
using Zenject;

public class ButtonInstaller : MonoInstaller
{
    [SerializeField]
    private Shading fadeImage;

    [SerializeField]
    private ResourceManager resourceManager;

    public override void InstallBindings()
    {
        Container.Bind<Shading>().FromInstance(fadeImage).AsSingle().NonLazy();
        Container.Bind<ResourceManager>().FromInstance(resourceManager).AsSingle().NonLazy();
    }
}