using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDB
{
    private Dictionary<int, EnemyData> _enemys = new();

    public EnemyDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var enemySO = Object.Instantiate(res);
        var entities = enemySO.EnemyDataBase;

        if (entities == null || entities.Count <= 0)
            return;

        var entityCount = entities.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var enemy = entities[i];

            if (_enemys.ContainsKey(enemy.Id))
                _enemys[enemy.Id] = enemy;
            else
                _enemys.Add(enemy.Id, enemy);
        }
    }

    public EnemyData Get(int id)
    {
        if (_enemys.ContainsKey(id))
            return _enemys[id];
        else
            return null;
    }
    public Dictionary<int, EnemyData> GetEnemyData() 
    { 
        return _enemys; 
    
    }

    public int GetCount()
    {
        return _enemys.Count;
    }
}