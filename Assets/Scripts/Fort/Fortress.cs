using System.Collections;
using UnityEngine;

public class Fortress : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackRange = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    public LayerMask enemyLayer; // EnemyLayer�� ����ϱ� ���� ����

    void Update()
    {
        Transform target = FindClosestEnemy();
        if (target != null)
        {
            // ������ �Ÿ��� ���� ���� ������ Ȯ��
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                // ���� ��ٿ��� �������� Ȯ��
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
        // ������Ÿ���� �����ϰ� ����� ���� �߻�
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
