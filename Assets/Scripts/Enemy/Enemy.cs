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
    public float Enemy_Atk { get {  return _enemy_Atk; } set { _enemy_Atk = value; } }
    public float Enemy_Def { get { return _enemy_Def; } set { _enemy_Def = value; } }
    public float Enemy_Speed { get { return _enemy_Speed; } set { _enemy_Speed = value; } }
    public float Enemy_AtkRange { get { return _enemy_AtkRange; } set { _enemy_AtkRange = value; } }
    public float Enemy_SpawnCycle { get { return _enemy_SpawnCycle; } set { _enemy_SpawnCycle = value; } }

}
public class Enemy : MonoBehaviour
{
    public EnemyState _enemyState;
    [SerializeField] private int _enemyId;

    public Transform target;
    private Vector2 tagetVec;
    bool isLive = true;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        _enemyState.Enemy_Name = DataBase.Enemy.Get(_enemyId).EnemyName;
        _enemyState.Enemy_Hp = DataBase.Enemy.Get(_enemyId).EnemyHp;
        _enemyState.Enemy_Atk = DataBase.Enemy.Get(_enemyId).EnemyAtk;
        _enemyState.Enemy_Def = DataBase.Enemy.Get(_enemyId).EnemyDef;
        _enemyState.Enemy_AtkRange = DataBase.Enemy.Get(_enemyId).EnemyAtkRange;
        _enemyState.Enemy_SpawnCycle = DataBase.Enemy.Get(_enemyId).EnemySpawnCycle;
        target = GameManager.Instance.Fort.transform;
        tagetVec = new Vector2(target.position.x, target.position.y);
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    //
    private void FixedUpdate()
    {
        if (!isLive)
            return;
        //플레이어의 키 입력값을 더한 이동 = 몬스터의 방향값을 더한 이동
        //방향 = 위치 차이의 정규화 (Normalized)
        //위치 차이 = 타겟 위치 -  나의 위치
        Vector2 dirVec = tagetVec - rigid.position;
        //프레임의 영향으로 결과가 달라지지 않도록 fixedDeltaTime 사용 
        Vector2 nextVec = dirVec.normalized * _enemyState.Enemy_Speed* Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        //물리 속도가 이동에 영향을 주지 않도록 속도 제거
        rigid.velocity = Vector2.zero;
    }

    //몬스터가 플레이어를 바라보는 방향이 자연스럽도록 함
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //몬스터가 무기와 충돌할때만 로직하도록
        if (!collision.CompareTag("Bullet"))
            return;
        Debug.Log("총알충돌");
        //몬스터가 가지고 있는 콜라이더의 접촉한 리지드바디를 가지고 있는 오브젝트
        _enemyState.Enemy_Hp -= collision.GetComponent<Bullet>().damage;

        //남은 체력을 조건으로 피격과 사망으로 로직 넣기
        if (_enemyState.Enemy_Hp > 0)
        {
            //..Live, HIt Act,,,
        }
        else
        {
            Debug.Log("몬스터 사망");

            //...Die
            Dead();
        }
    }

    //사망할떄는 SetActive 함수를 이용한 오브젝트 비활성화
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
