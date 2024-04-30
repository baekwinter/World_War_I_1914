using UnityEngine;

[System.Serializable]
public class EnemyData 
{
    [SerializeField] private int _id;
    [SerializeField] private string _enemyKorName;
    [SerializeField] private string _enemyEngName;
    [SerializeField] private float _enemyHp;
    [SerializeField] private float _enemyAtk;
    [SerializeField] private float _enemyDef;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyAtkRange;
    [SerializeField] private float _enemySpawnCycle;
    [SerializeField] private string _enemyPrefabPath;
    [SerializeField] private float _enemyDropHpItem;
    [SerializeField] private float _enemyDropGold;
    [SerializeField] private float _enemyDropExp;

    //프로퍼티 
    public int Id => _id;
    public string EnemyKorName => _enemyKorName;
    public string EnemyEngName => _enemyEngName;
    public float EnemyHp => _enemyHp;
    public float EnemyAtk => _enemyAtk;
    public float EnemyDef => _enemyDef;
    public float EnemySpeed => _enemySpeed;
    public float EnemyAtkRange => _enemyAtkRange;
    public float EnemySpawnCycle => _enemySpawnCycle;   
    public string EnemyPrefabPath => _enemyPrefabPath;
    public float EnemyDropHpItem => _enemyDropHpItem;
    public float EnemyDropGold => _enemyDropGold;
    public float EnemyDropExp => _enemyDropExp;
}


