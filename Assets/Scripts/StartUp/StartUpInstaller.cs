using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using SaveLoadSystem;

namespace Installers
{
    public class StartUpInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameScenarioRunner>().FromNew().AsSingle();
            Container.Bind<GameSaveLoader>().FromNew().AsSingle();

        }
    }
}
