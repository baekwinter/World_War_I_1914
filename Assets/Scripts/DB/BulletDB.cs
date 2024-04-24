using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDB 
{
    private Dictionary<int, BulletData> _bullets = new();

    public BulletDB()
    {
        var res = Resources.Load<Unit_DataBase>("DataBase/Unit_DataBase");
        var bulletSO = Object.Instantiate(res);
        var entities = bulletSO.BulletDataBase;

        if (entities == null || entities.Count <= 0)
            return;

        var entityCount = entities.Count;
        for (int i = 0; i < entityCount; i++)
        {
            var bullet = entities[i];

            if (_bullets.ContainsKey(bullet.Id))
                _bullets[bullet.Id] = bullet;
            else
                _bullets.Add(bullet.Id, bullet);
        }
    }

    public BulletData Get(int id)
    {
        if (_bullets.ContainsKey(id))
            return _bullets[id];
        else
            return null;
    }
    public Dictionary<int, BulletData> GetEnemyData()
    {
        return _bullets;

    }

    public int GetCount()
    {
        return _bullets.Count;
    }

    internal float Get(float bulletAtk)
    {
        throw new System.NotImplementedException();
    }
}
