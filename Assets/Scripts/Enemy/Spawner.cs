using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //��ȯ�� ������ ������
    public GameObject enemyPrefab;
    // ���͸� ��ȯ�� ��ġ ���
    public List<Transform> spawnPoints;

    //���͸� ��ȯ�� ���� 
    private void Start()
    {
        PoolManager.Instance.Test();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" ������");
            PoolManager.Instance.Get(0).transform.position = GetRandomCircleSpawnPosition(10);
        }
    }

    public Vector3 GetRandomCircleSpawnPosition(float radius)
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;

        float dis = Vector3.Distance(randomPos, Vector3.zero);
        float per = radius / dis;

        randomPos *= per;

        randomPos += GameManger.Instance.Player.position;

        return randomPos;
    }
}
