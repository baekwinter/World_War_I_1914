using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //소환할 몬스터의 프리팹
    public GameObject enemyPrefab;
    // 몬스터를 소환할 위치 목록
    public List<Transform> spawnPoints;
    private void Start()
    {
        PoolManager.Instance.Test();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" 눌렸음");
            PoolManager.Instance.Get(0);
        }
    }

    void SpawnEnemyAtRandomPoint()
    {
        if(spawnPoints.Count > 0) 
        {
            // 무작위 위치에서 몬스터 소환하기 
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];

            //PoolManager를 이용한 몬스터 소환

            GameObject enemy = PoolManager.Instance.Get(0);
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation; 
        }
        else
        {
            Debug.Log("스폰 포인트가 할당되지 않았습니다.");
        }
    }
}
