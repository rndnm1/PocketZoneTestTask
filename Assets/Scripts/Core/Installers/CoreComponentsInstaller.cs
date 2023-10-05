using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Installers
{
    public class CoreComponentsInstaller : MonoInstaller
    {
        [SerializeField] private PrefabManager prefabManagerInstance;
        public override void InstallBindings()
        {
            Container.Bind<PrefabManager>().FromInstance(prefabManagerInstance);
            Container.Bind<DataBase>().FromNew().AsSingle();
        }
    }
}
