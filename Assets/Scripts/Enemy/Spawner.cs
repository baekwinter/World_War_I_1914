using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //��ȯ�� ������ ������
    public GameObject enemyPrefab;
    // ���͸� ��ȯ�� ��ġ ���
    public List<Transform> spawnPoints;
    private void Start()
    {
        PoolManager.Instance.Test();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" ������");
            PoolManager.Instance.Get(0);
        }
    }

    void SpawnEnemyAtRandomPoint()
    {
        if(spawnPoints.Count > 0) 
        {
            // ������ ��ġ���� ���� ��ȯ�ϱ� 
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];

            //PoolManager�� �̿��� ���� ��ȯ

            GameObject enemy = PoolManager.Instance.Get(0);
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation; 
        }
        else
        {
            Debug.Log("���� ����Ʈ�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
}
