using UnityEngine;

[System.Serializable]
public class EnemyData 
{
    [SerializeField] private int _id;
    [SerializeField] private string _enemyName;
    [SerializeField] private float _enemyHp;
    [SerializeField] private float _enemyAtk;
    [SerializeField] private float _enemyDef;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyAtkRange;
    [SerializeField] private float _enemySpawnCycle;

    //프로퍼티 
    public int id => _id;
    public string enemyName => _enemyName;
    public float enemyHp => _enemyHp;
    public float enemyAtk => _enemyAtk;
    public float enemyDef => _enemyDef;
    public float enemySpeed => _enemySpeed;
    public float enemyAtkRange => _enemyAtkRange;
    public float enemySpawnCycle => _enemySpawnCycle;   
}


