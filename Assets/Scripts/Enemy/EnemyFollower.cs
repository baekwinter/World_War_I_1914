using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    // �÷��̾� ������Ʈ�� Ʈ������
    public Transform playerTransform;
    //������ �̵��ӵ�
    public float _enemySpeed = 5.0f;

     void Start()
    {
        playerTransform = GameManager.Instance.Fort;
    }
     void Update()
    {
        // playerTransform�� �Ҵ���� �ʾҴٸ�, �ƹ��͵� ���� �ʰ� ��ȯ�϶�
        if (playerTransform == null) return;
        
        //�÷��̾��� ���� ��ġ�� ���� ���� �̵�
        Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Vector2 newPosition = new Vector2 (transform.position.x, transform.position.y) + directionToPlayer * _enemySpeed * Time.deltaTime;
        //������ ��ġ�� ���ο� ��ġ�� ������Ʈ
        transform.position = newPosition;
        
    }
}