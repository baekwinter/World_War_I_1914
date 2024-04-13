using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortDB 
{
    private Dictionary<int, FortData> _forts = new();

    public FortDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var fortSO = Object.Instantiate(res);
        var entities = fortSO.FortDataBase;

        if (entities == null || entities.Count <= 0)
            return;

        var entityCount = entities.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var enemy = entities[i];

            if (_forts.ContainsKey(enemy.Id))
                _forts[enemy.Id] = enemy;
            else
                _forts.Add(enemy.Id, enemy);
        }
    }

    public FortData Get(int id)
    {
        if (_forts.ContainsKey(id))
            return _forts[id];
        else
            return null;
    }
    public Dictionary<int, FortData> GetFortData()
    {
        return _forts;

    }

    public int GetCount()
    {
        return _forts.Count;
    }
}
