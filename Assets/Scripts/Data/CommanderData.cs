using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CommanderData
{

    [SerializeField] private int _id;
    [SerializeField] private string _commanderName;
    [SerializeField] private float _commanderHp;
    [SerializeField] private float _commanderAtk;
    [SerializeField] private float _commanderDef;

    [SerializeField] private float _commanderSpeed;
    [SerializeField] private float _commanderAtkRange;
    [SerializeField] private string _commanderProperties;
    [SerializeField] private string _commanderPrefabPath;

    //프로퍼티 
    public int Id => _id;
    public string CommanderName => _commanderName;
    public float CommanderHp => _commanderHp;
    public float CommanderAtk => _commanderAtk;
    public float CommanderDef => _commanderDef;
    public float CommanderSpeed => _commanderSpeed;
    public float CommanderAtkRange => _commanderAtkRange;
    public string CommanderProperties => _commanderProperties;
    public string CommanderPrefabPath => _commanderPrefabPath;
}
