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
        //�÷��̾��� Ű �Է°��� ���� �̵� = ������ ���Ⱚ�� ���� �̵�
        //���� = ��ġ ������ ����ȭ (Normalized)
        //��ġ ���� = Ÿ�� ��ġ -  ���� ��ġ
        Vector2 dirVec = tagetVec - rigid.position;
        //�������� �������� ����� �޶����� �ʵ��� fixedDeltaTime ��� 
        Vector2 nextVec = dirVec.normalized * _enemyState.Enemy_Speed* Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        //���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ����
        rigid.velocity = Vector2.zero;
    }

    //���Ͱ� �÷��̾ �ٶ󺸴� ������ �ڿ��������� ��
    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���Ͱ� ����� �浹�Ҷ��� �����ϵ���
        if (!collision.CompareTag("Bullet"))
            return;
        Debug.Log("�Ѿ��浹");
        //���Ͱ� ������ �ִ� �ݶ��̴��� ������ ������ٵ� ������ �ִ� ������Ʈ
        _enemyState.Enemy_Hp -= collision.GetComponent<Bullet>().damage;

        //���� ü���� �������� �ǰݰ� ������� ���� �ֱ�
        if (_enemyState.Enemy_Hp > 0)
        {
            //..Live, HIt Act,,,
        }
        else
        {
            Debug.Log("���� ���");

            //...Die
            Dead();
        }
    }

    //����ҋ��� SetActive �Լ��� �̿��� ������Ʈ ��Ȱ��ȭ
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
