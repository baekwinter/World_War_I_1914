using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    // 플레이어 오브젝트의 트랜스폼
    public Transform playerTransform;
    //몬스터의 이동속도
    public float _enemySpeed = 5.0f;

     void Start()
    {
        playerTransform = GameManager.Instance.Fort;
    }
     void Update()
    {
        // playerTransform이 할당되지 않았다면, 아무것도 하지 않고 반환하라
        if (playerTransform == null) return;
        
        //플레이어의 현재 위치를 향해 몬스터 이동
        Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Vector2 newPosition = new Vector2 (transform.position.x, transform.position.y) + directionToPlayer * _enemySpeed * Time.deltaTime;
        //몬스터의 위치를 새로운 위치로 업데이트
        transform.position = newPosition;
        
    }
}