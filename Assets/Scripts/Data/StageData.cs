using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData 
{

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _enemygroupid;


    //프로퍼티 
    public int Id => _id;
    public string StageName => _name;
    public string Description => _description;
    public int  EnemyGroupId => _enemygroupid;

}

