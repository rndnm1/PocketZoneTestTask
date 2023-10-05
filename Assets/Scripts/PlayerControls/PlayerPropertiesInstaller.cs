using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using PlayerControls;
using InventoryModule;

public class PlayerPropertiesInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private PrefabManager prefabManagerInstance;
    [SerializeField] private GameObject controlsInput;
    public override void InstallBindings()
    {
        Container.Bind<GameObject>().FromInstance(playerObject).AsSingle();
        Container.Bind<Inventory>().FromInstance(playerObject.GetComponent<Inventory>()).AsSingle();
        Container.Bind<IMovementControlsInputSource>().FromInstance(controlsInput.GetComponent<IMovementControlsInputSource>()).AsSingle();
        Container.Bind<PlayerController>().FromInstance(playerObject.GetComponent<PlayerController>()).AsSingle();
    }
}
