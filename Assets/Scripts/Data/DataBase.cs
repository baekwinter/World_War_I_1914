using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DataBase : MonoBehaviour
{
    private static EnemyDB _enemy;
    private static EnemyGroupDB _enemyGroups;
    private static FortDB _forts;
    private static CommanderDB _commanders;
    private static StageDB _stages;



    public static EnemyDB Enemy
    {
        get
        {
            if (_enemy == null)
                _enemy = new EnemyDB();

            return _enemy;
        }
    }

    public static EnemyGroupDB EnemyGroup
    {
        get
        {
            if (_enemyGroups == null)
                _enemyGroups = new EnemyGroupDB();

            return _enemyGroups;
        }
    }

    public static FortDB Fort

    {
        get
        {
            if (_forts == null)
                _forts = new FortDB();

            return _forts;
        }
    }

    public static CommanderDB Commander

    {
        get
        {
            if (_commanders == null)
                _commanders = new CommanderDB();

            return _commanders;
        }
    }

    public static StageDB Stage

    {
        get
        {
            if (_stages == null)
                _stages = new StageDB();

            return _stages;
        }
    }
}