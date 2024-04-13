using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDB 
{
    private Dictionary<int, StageData> _stages = new();

    public StageDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var stageSO = Object.Instantiate(res);
        var entities = stageSO.StageDataBase;

        if (entities == null || entities.Count <= 0)
            return;

        var entityCount = entities.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var stage = entities[i];

            if (_stages.ContainsKey(stage.Id))
                _stages[stage.Id] = stage;
            else
                _stages.Add(stage.Id, stage);
        }
    }

    public StageData Get(int id)
    {
        if (_stages.ContainsKey(id))
            return _stages[id];
        else
            return null;
    }
    public Dictionary<int, StageData> GetStageData()
    {
        return _stages;

    }

    public int GetCount()
    {
        return _stages.Count;
    }
}
