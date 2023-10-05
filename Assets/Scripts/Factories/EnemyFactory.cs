using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public class EnemyFactory : PlaceholderFactory<Unit>
{
    private DataBase dataBase;

    [Inject]
    private EnemyFactory(DataBase dataBase)
    {
        this.dataBase = dataBase;   
    }

    public override Unit Create()
    {
        Unit newUnit = base.Create();

        dataBase.UnitsPool.Add(newUnit.gameObject);
        newUnit.UnitID = dataBase.UnitsPool.IndexOf(newUnit.gameObject);

        return newUnit;
    }
}
