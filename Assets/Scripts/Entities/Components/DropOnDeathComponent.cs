using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

[RequireComponent(typeof(HealthComponent))]
public class DropOnDeathComponent : MonoBehaviour
{
    public Item itemDroppedOnDeath = null;


    private void Awake()
    {
        GetComponent<HealthComponent>().OnDeath += CreateItemOnDeath;
    }

    public void CreateItemOnDeath()
    {
        if (itemDroppedOnDeath != null)
        {
            GameObject.Instantiate(PrefabManager.CollectibleItemPrefab, transform.position, Quaternion.identity).GetComponent<CollectableObject>().storedItem = itemDroppedOnDeath;
        }
    }
}
