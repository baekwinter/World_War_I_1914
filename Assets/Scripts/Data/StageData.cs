using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData 
{

    [SerializeField] private int _id;
    [SerializeField] private string _engName;   
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _enemyGroupId;
    [SerializeField] private int _stageBattleTime;


    //프로퍼티 
    public int Id => _id;
    public string StageEngName => _engName;
    public string StageName => _name;
    public string Description => _description;
    public int  EnemyGroupId => _enemyGroupId;
    public int StageBattleTime => _stageBattleTime;
}

