using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FortData 
{
    [SerializeField] private int _id;
    [SerializeField] private string _fortName;
    [SerializeField] private float _fortHp;
    [SerializeField] private float _fortAtk;
    [SerializeField] private float _fortDef;
    [SerializeField] private float _fortSpeed;
    [SerializeField] private float _fortAtkRange;
    [SerializeField] private string _fortPrefabPath;

    //프로퍼티 
    public int Id => _id;
    public string FortName => _fortName;
    public float FortHp => _fortHp;
    public float FortAtk => _fortAtk;
    public float FortDef => _fortDef;
    public float FortSpeed => _fortSpeed;
    public float FortAtkRange => _fortAtkRange;
    public string FortPrefabPath => _fortPrefabPath;

}
