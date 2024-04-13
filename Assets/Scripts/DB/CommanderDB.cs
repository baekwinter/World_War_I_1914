using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderDB 
{
    private Dictionary<int, CommanderData> _commanders = new();

    public CommanderDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var commanderSO = Object.Instantiate(res);
        var commanders = commanderSO.CommanderDataBase;

        if (commanders == null || commanders.Count <= 0)
            return;

        var entityCount = commanders.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var commander = commanders[i];

            if (_commanders.ContainsKey(commander.Id))
                _commanders[commander.Id] = commander;
            else
                _commanders.Add(commander.Id, commander);
        }
    }

    public CommanderData Get(int id)
    {
        if (_commanders.ContainsKey(id))
            return _commanders[id];
        else
            return null;
    }
    public Dictionary<int, CommanderData> GetCommanderData()
    {
        return _commanders;

    }

    public int GetCount()
    {
        return _commanders.Count;
    }
}
