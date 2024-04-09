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
    [SerializeField] private string _enemyPrefabPath;

    //프로퍼티 
    public int Id => _id;
    public string EnemyName => _enemyName;
    public float EnemyHp => _enemyHp;
    public float EnemyAtk => _enemyAtk;
    public float EnemyDef => _enemyDef;
    public float EnemySpeed => _enemySpeed;
    public float EnemyAtkRange => _enemyAtkRange;
    public float EnemySpawnCycle => _enemySpawnCycle;   
    public string EnemyPrefabPath => _enemyPrefabPath;
}


