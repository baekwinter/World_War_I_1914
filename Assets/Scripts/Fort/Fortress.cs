using System.Collections;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackRange = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    public LayerMask enemyLayer; // EnemyLayer를 사용하기 위한 변수

    void Update()
    {
        Transform target = FindClosestEnemy();
        if (target != null)
        {
            // 대상과의 거리가 공격 범위 내인지 확인
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                // 공격 쿨다운이 지났는지 확인
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    Attack(target);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    void Attack(Transform target)
    {
        // 프로젝타일을 생성하고 대상을 향해 발사
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if (projectileScript != null)
        {
            projectileScript.Launch(target.position);
        }
    }

    Transform FindClosestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = hit.transform;
            }
        }

        return closestEnemy;
    }
}
