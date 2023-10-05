using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Unit, EnemyFactory>().FromComponentInNewPrefab(PrefabManager.EnemyPrefab).AsSingle();
        }
    }
}
