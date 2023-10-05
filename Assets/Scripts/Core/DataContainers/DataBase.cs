using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

/// <summary>
/// Stores information about any entity in the game
/// </summary>
public class DataBase
{
    [HideInInspector] public List<GameObject> UnitsPool = new List<GameObject>();
    [HideInInspector] public GameObject PlayerObject;

    [Inject]
    private DataBase(GameObject playerObject)
    {
        PlayerObject = playerObject;
    }
}
