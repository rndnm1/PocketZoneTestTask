using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SerializableUnitData
    {
        public float CurrentHP;

        public float PositionX;
        public float PositionY;


        public SerializableUnitData(GameObject playerObjectToSaveData)
        {
            CurrentHP = playerObjectToSaveData.GetComponent<HealthComponent>().CurrentHP;
            PositionX = playerObjectToSaveData.transform.position.x;
            PositionY = playerObjectToSaveData.transform.position.y;
        }

        public virtual void UnloadAllData(GameObject objectToUnloadData)
        {
            UnloadDataToUnit(objectToUnloadData);
        }
        internal void UnloadDataToUnit(GameObject unitToUnloadData)
        {
            unitToUnloadData.transform.position = new Vector3(PositionX, PositionY, 0);

            if (unitToUnloadData.TryGetComponent(out HealthComponent unitHealthComponent))
            {
                unitHealthComponent.CurrentHP = CurrentHP;
                unitHealthComponent.RecieveDamage(0);
            }
        }

    }
}
