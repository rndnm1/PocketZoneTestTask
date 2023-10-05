using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public class GameScenarioRunner
{
    private EnemyFactory enemyFactory;
    private DataBase dataBase;

    [Inject]
    private GameScenarioRunner(EnemyFactory enemyFactory, DataBase dataBase)
    {
        this.enemyFactory = enemyFactory;
        this.dataBase = dataBase;
    }

    public void RunScenario(LevelScenario scenarioToRun)
    {
        //Spawn enemies through factory
        for (int enemiesToSpawnCounter = dataBase.UnitsPool.Count; enemiesToSpawnCounter < scenarioToRun.countEnemiesToSpawn; enemiesToSpawnCounter++)
        {
            GameObject newEnemy = enemyFactory.Create().gameObject;
            newEnemy.transform.position = new Vector3(Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), 0);
        }

        //Spawn ammo
        for (int ammoToSpawnCounter = 0; ammoToSpawnCounter < scenarioToRun.countAmmoToSpawn; ammoToSpawnCounter++)
        {
            GameObject ammoCrate = GameObject.Instantiate(PrefabManager.CollectibleItemPrefab);
            ammoCrate.transform.position = new Vector3(Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), Random.Range(-scenarioToRun.MapRadius, scenarioToRun.MapRadius), 0);
        }
    }
}
