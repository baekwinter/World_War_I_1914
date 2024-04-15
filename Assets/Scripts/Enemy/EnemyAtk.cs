using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾� ������Ʈ�� Ʈ������
    public float attackRange = 1.5f; // ���� ����
    public float attackRate = 1.0f; // ���� �ӵ� (�� ����)
    private float lastAttackTime; // ������ ���� �ð�

    void Start()
    {
        playerTransform = GameManager.Instance.Fort;
    }

    void Update()
    {
        if (playerTransform == null) return;

        // �÷��̾���� �Ÿ��� ����մϴ�.
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // �÷��̾ ���� ���� ���� �ְ�, ������ ���� �ð����κ��� ����� �ð��� �����ٸ� �����մϴ�.
        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackRate)
        {
            AttackPlayer();
            lastAttackTime = Time.time; // ������ ���� �ð��� ������Ʈ�մϴ�.
        }
    }

    void AttackPlayer()
    {
        // �÷��̾�� �������� �ִ� ������ ���⿡ �����մϴ�.
        Debug.Log("�÷��̾ �����մϴ�!");
    }
}
