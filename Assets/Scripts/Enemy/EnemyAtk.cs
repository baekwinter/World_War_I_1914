using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    public Transform playerTransform; // 플레이어 오브젝트의 트랜스폼
    public float attackRange = 1.5f; // 공격 범위
    public float attackRate = 1.0f; // 공격 속도 (초 단위)
    private float lastAttackTime; // 마지막 공격 시간

    void Start()
    {
        playerTransform = GameManager.Instance.Fort;
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 플레이어와의 거리를 계산합니다.
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // 플레이어가 공격 범위 내에 있고, 마지막 공격 시간으로부터 충분한 시간이 지났다면 공격합니다.
        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackRate)
        {
            AttackPlayer();
            lastAttackTime = Time.time; // 마지막 공격 시간을 업데이트합니다.
        }
    }

    void AttackPlayer()
    {
        // 플레이어에게 데미지를 주는 로직을 여기에 구현합니다.
        Debug.Log("플레이어를 공격합니다!");
    }
}
