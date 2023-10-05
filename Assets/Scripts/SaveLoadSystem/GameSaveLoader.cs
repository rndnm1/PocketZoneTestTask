using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Zenject;

namespace SaveLoadSystem
{
    public class GameSaveLoader
    {
        private EnemyFactory enemyFactory;
        private DataBase dataBaseToSave;

        [Inject]
        private GameSaveLoader(EnemyFactory enemyFactory, DataBase dataBaseToSave)
        {
            this.enemyFactory = enemyFactory;
            this.dataBaseToSave = dataBaseToSave;
        }
        public void SaveGameState()
        {
            SavedGameData savedGame = new SavedGameData();

            //Saving all units
            foreach (var unitToSave in dataBaseToSave.UnitsPool)
            {
                if (unitToSave != null) savedGame.SavedUnitsData.Add(new SerializableUnitData(unitToSave));
            }
            if (dataBaseToSave.PlayerObject != null) savedGame.SavedUnitsData.Add(new SerializablePlayerData(dataBaseToSave.PlayerObject));

            //Saving data to file
            SerializationManager.Save("LastGameSave", savedGame);
        }
        public bool LoadGame()
        {
            SavedGameData loadedSave = (SavedGameData)SerializationManager.Load("LastGameSave");
            if (loadedSave == null) return false;

            //Load all units
            foreach (SerializableUnitData unitData in loadedSave.SavedUnitsData)
            {
                if (unitData is SerializablePlayerData) (unitData as SerializablePlayerData).UnloadAllData(dataBaseToSave.PlayerObject);
                else
                {
                    unitData.UnloadAllData(enemyFactory.Create().gameObject);
                }
            }

            return true;
        }
    }
}
