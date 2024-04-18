using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyState
{
    [SerializeField] private string _enemy_Name;
    [SerializeField] private float _enemy_Hp;
    [SerializeField] private float _enemy_Atk;
    [SerializeField] private float _enemy_Def;
    [SerializeField] private float _enemy_Speed;
    [SerializeField] private float _enemy_AtkRange;
    [SerializeField] private float _enemy_SpawnCycle;

    public string Enemy_Name { get { return _enemy_Name; } set { _enemy_Name = value; } }
    public float Enemy_Hp { get { return _enemy_Hp; } set { _enemy_Hp = value; } }
    public float Enemy_Atk { get { return _enemy_Atk; } set { _enemy_Atk = value; } }
    public float Enemy_Def { get { return _enemy_Def; } set { _enemy_Def = value; } }
    public float Enemy_Speed { get { return _enemy_Speed; } set { _enemy_Speed = value; } }
    public float Enemy_AtkRange { get { return _enemy_AtkRange; } set { _enemy_AtkRange = value; } }
    public float Enemy_SpawnCycle { get { return _enemy_SpawnCycle; } set { _enemy_SpawnCycle = value; } }
}

public class Enemy : MonoBehaviour
{
    public EnemyState _enemyState;
    [SerializeField] private int _enemyId;

    public Transform _target;
    private Vector2 targetVec;
    bool isLive = true;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        var enemyData = DataBase.Enemy.Get(_enemyId);
        if (enemyData != null) // enemyData가 null이 아닌지 확인
        {
            _enemyState.Enemy_Name = enemyData.EnemyName;
            _enemyState.Enemy_Hp = enemyData.EnemyHp;
            _enemyState.Enemy_Atk = enemyData.EnemyAtk;
            _enemyState.Enemy_Def = enemyData.EnemyDef;
            _enemyState.Enemy_AtkRange = enemyData.EnemyAtkRange;
            _enemyState.Enemy_SpawnCycle = enemyData.EnemySpawnCycle;
            _enemyState.Enemy_Speed = enemyData.EnemySpeed;
        }
        else
        {
            Debug.LogError("Enemy data is null for enemyId: " + _enemyId);
        }

        // GameManager의 인스턴스와 Fort가 null이 아닌지 확인 후 _target 할당
        if (GameManager.Instance != null && GameManager.Instance.Fort != null)
        {
            _target = GameManager.Instance.Fort.transform;
        }
        else
        {
            Debug.LogError("GameManager.Instance or GameManager.Instance.Fort is null");
        }

        // target이 null이 아니면 targetVec를 업데이트, 아니면 Vector2.zero 할당
        targetVec = _target != null ? new Vector2(_target.position.x, _target.position.y) : Vector2.zero;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        // 플레이어 방향으로 이동 로직
        Vector2 dirVec = targetVec - rigid.position;
        Vector2 nextVec = dirVec.normalized * _enemyState.Enemy_Speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive || _target == null)
            return;

        // 몬스터가 플레이어를 바라보는 방향 설정
        spriter.flipX = _target.position.x < rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        Debug.Log("총알충돌");
        _enemyState.Enemy_Hp -= collision.GetComponent<Bullet>().damage;

        // 체력에 따른 로직 처리
        if (_enemyState.Enemy_Hp > 0)
        {
            // 피격 로직
        }
        else
        {
            Debug.Log("몬스터 사망");
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
