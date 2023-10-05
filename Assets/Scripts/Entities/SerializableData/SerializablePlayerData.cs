using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SerializablePlayerData : SerializableUnitData
    {
        public List<int> StoredItemIDs;

        public SerializablePlayerData(GameObject playerObjectToSaveData) : base(playerObjectToSaveData)
        {
            CurrentHP = playerObjectToSaveData.GetComponent<HealthComponent>().CurrentHP;
            PositionX = playerObjectToSaveData.transform.position.x;
            PositionY = playerObjectToSaveData.transform.position.y;

            StoredItemIDs = playerObjectToSaveData.GetComponent<Inventory>().GetListOfItemIDs();
        }

        public override void UnloadAllData(GameObject unitToUnloadData)
        {
            UnloadInventoryData(unitToUnloadData);
        }
      
        private void UnloadInventoryData(GameObject unitToUnloadData)
        {
            if (unitToUnloadData.TryGetComponent(out Inventory inventory))
            {
                for (int i = 0; i < StoredItemIDs.Count; i++) inventory.AddItem(ItemsManager.ItemTypes[StoredItemIDs[i]]);
            }
        }
    }
}
