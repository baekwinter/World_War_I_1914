using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FortState
{
    [SerializeField] private string _fort_Name;
    [SerializeField] private float _fort_Hp;
    [SerializeField] private float _fort_Atk;
    [SerializeField] private float _fort_Def;
    [SerializeField] private float _fort_Speed;
    [SerializeField] private float _fort_AtkRange;

    //프로퍼티
    public string Fort_Name { get { return _fort_Name; } set { _fort_Name = value; } }
    public float Fort_Hp { get { return _fort_Hp; } set { _fort_Hp = value; } }
    public float Fort_Atk { get { return _fort_Atk; } set { _fort_Atk = value; } }
    public float Fort_Def { get { return _fort_Def; } set { _fort_Def = value; } }
    public float Fort_Speed { get { return _fort_Speed; } set { _fort_Speed = value; } }
    public float Fort_AtkRange { get { return _fort_AtkRange; } set { _fort_AtkRange = value; } }

}
public class Fort : MonoBehaviour
{
    [SerializeField] public FortState _fortState;
    [SerializeField] private int _fortId;
    
    private void Awake()
    {
        _fortState.Fort_Name = DataBase.Fort.Get(_fortId).FortName;
        _fortState.Fort_Hp = DataBase.Fort.Get(_fortId).FortHp;
        _fortState.Fort_Atk = DataBase.Fort.Get(_fortId).FortAtk;
        _fortState.Fort_Def = DataBase.Fort.Get(_fortId).FortDef;
        _fortState.Fort_AtkRange = DataBase.Fort.Get(_fortId).FortAtkRange;
        _fortState.Fort_Speed = DataBase.Fort.Get(_fortId).FortSpeed;
    }

}
