using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SavedGameData
    {
        public List<SerializableUnitData> SavedUnitsData = new List<SerializableUnitData>();
    }
}
