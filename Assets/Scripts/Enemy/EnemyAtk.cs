using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
     // �÷��̾� ��ġ
    public GameObject bulletPrefab; // �Ѿ� ������
    public float attackRange; // ���� ����
    public float bulletSpeed = 30f; // �Ѿ� �ӵ�
    public float attackRate = 0.5f; // ���� �ӵ� (�� ����)
    private float lastAttackTime; // ������ ���� �ð�
    private Enemy _enemy;
    private EnemyFollower _enemyFollower;
    private Transform _target;
    private void Awake()
    {
        
        _enemy = GetComponent<Enemy>();
        _enemyFollower = GetComponent<EnemyFollower>();
    }

    private void Start()
    {
        attackRange = _enemy._enemyState.Enemy_AtkRange;
    }
    void Update()
    {
        _target = GameManager.Instance.Fort.transform;
        float distanceToNearestTarget = Vector2.Distance(_target.position, _enemy.target.position);
        if (distanceToNearestTarget <= attackRange && Time.time - lastAttackTime >= attackRate)
        {
            _enemyFollower._enemySpeed = 0f;
            Shoot(_target.position);
            lastAttackTime = Time.time;
        }
        else
        {
            _enemyFollower._enemySpeed = _enemy._enemyState.Enemy_Speed;
        }
    }

    void Shoot(Vector2 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 targetDirection = (targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = targetDirection * bulletSpeed;
        Debug.Log("�Ѿ��� �߻�Ǿ����ϴ�!");
        Debug.Log(targetDirection);
    }

}
