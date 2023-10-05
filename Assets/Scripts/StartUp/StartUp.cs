using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using SaveLoadSystem;

namespace StartUp
{
    /// <summary>
    /// Entry point of the game
    /// </summary>
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private LevelScenario scenarioToRun;

        private GameSaveLoader saveLoader;
        private GameScenarioRunner scenarioRunner;

        [Inject]
        private void InstallExternalDependencies(GameSaveLoader saveLoader, GameScenarioRunner scenarioRunner)
        {
            this.saveLoader = saveLoader;
            this.scenarioRunner = scenarioRunner;
        }

        private void Start()
        {
            saveLoader.LoadGame();
            scenarioRunner.RunScenario(scenarioToRun);
        }
        private void OnApplicationQuit()
        {
            saveLoader.SaveGameState();
        }
    }
}
