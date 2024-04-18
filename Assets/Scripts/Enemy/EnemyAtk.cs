using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    // 플레이어 위치
    public GameObject bulletPrefab; // 총알 프리팹
    public float attackRange; // 공격 범위
    public float bulletSpeed = 30f; // 총알 속도
    public float attackRate = 1f; // 공격 속도 (초 단위)
    private float lastAttackTime; // 마지막 공격 시간
    private Enemy _enemy;
    private EnemyFollower _enemyFollower;
    
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
        //Distance. 
        float distanceToNearestTarget = Vector2.Distance(_enemy._target.position, transform.position);
        //Debug.Log(distanceToNearestTarget);
        //Debug.Log(attackRange);
        if (distanceToNearestTarget <= attackRange)
        {
            _enemyFollower._enemySpeed = 0f;
            if (Time.time - lastAttackTime >= attackRate)
            {
                Shoot(_enemy._target.position);
                lastAttackTime = Time.time;

            }
            return;
        }
        //Debug.Log("공격범위 벗어남");
        //Debug.Log(_enemy._enemyState.Enemy_Speed);
        _enemyFollower._enemySpeed = _enemy._enemyState.Enemy_Speed;

    }

    void Shoot(Vector2 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 targetDirection = (targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = targetDirection * bulletSpeed;
    }

}
