using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public BoardMatchController matchController;
    public BoardCreateController createController;

    public override void InstallBindings()
    {
        Container.BindInstance(matchController).AsSingle();
        Container.BindInstance(createController).AsSingle();
    }
}