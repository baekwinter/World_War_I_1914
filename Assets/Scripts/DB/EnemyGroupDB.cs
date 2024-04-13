using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupDB
{
    private Dictionary<int, EnemyGroupData> _enemyGroups = new();

    public EnemyGroupDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var enemyGroupSO = Object.Instantiate(res);
        var entities = enemyGroupSO.EnemyGroupDataBase;

        if (entities == null || entities.Count <= 0)
            return;

        var entityCount = entities.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var enemyGroup = entities[i];

            if (_enemyGroups.ContainsKey(enemyGroup.Id))
                _enemyGroups[enemyGroup.Id] = enemyGroup;
            else
                _enemyGroups.Add(enemyGroup.Id, enemyGroup);
        }
    }

    public EnemyGroupData Get(int id)
    {
        if (_enemyGroups.ContainsKey(id))
            return _enemyGroups[id];
        else
            return null;
    }
    public Dictionary<int, EnemyGroupData> GetEnemyGroupData()
    {
        return _enemyGroups;

    }

    public int GetCount()
    {
        return _enemyGroups.Count;
    }
}
