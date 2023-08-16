using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerInstaller : MonoInstaller
{
    [SerializeField]private  BoardMatchController matchController;


    public override void InstallBindings()
    {
        Container.BindInstance(matchController).AsSingle();
    }
}
