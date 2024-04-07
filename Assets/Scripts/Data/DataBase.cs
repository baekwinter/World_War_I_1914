using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DataBase : MonoBehaviour
{
    private static EnemyDB _enemy;
    
    public static EnemyDB Enemy
    {
        get
        {
            if (_enemy == null)
                _enemy = new EnemyDB();

            return _enemy;
        }
    }

}