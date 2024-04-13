using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroupData 
{

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _groupEnemyNum;
    [SerializeField] private int _enemyId0;
    [SerializeField] private int _enemyId1;
    [SerializeField] private int _enemyId2;


    //프로퍼티 
    public int Id => _id;
    public string EnemyGroupName => _name;
    public int GroupEnemyNum => _groupEnemyNum;
    public int  EnemyGroupId0 => _enemyId0;
    public int EnemyGroupId1 => _enemyId1;
    public int EnemyGroupId2 => _enemyId2;
}

