using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //소환할 몬스터의 프리팹
    public GameObject enemyPrefab;
    // 몬스터를 소환할 위치 목록
    public List<Transform> spawnPoints;

    //몬스터를 소환할 범위 
    private void Start()
    {
        PoolManager.Instance.Test();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" 눌렸음");
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
