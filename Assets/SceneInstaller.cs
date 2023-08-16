using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public BoardMatchController matchController;
    public override void InstallBindings()
    {
        Debug.Log("asdas");
        Container.BindInstance(matchController).AsSingle();
    }
}