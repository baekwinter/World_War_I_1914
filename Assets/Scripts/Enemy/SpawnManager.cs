using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //소환할 몬스터의 프리팹
    public GameObject enemyPrefab;
   // 몬스터를 소환할 위치 목록
    public List<Transform> spawnPoints;

   // 몬스터를 소환할 범위
    private void Start()
    {
        StartCoroutine(StartNichiSoldierSpawn());
        StartCoroutine(StartNichiSniper_Spawn());
        StartCoroutine(StartNichiGunner_Spawn());
    }


    public Vector3 GetRandomCircleSpawnPosition(float radius)
    {
        Vector3 randomPos = Random.insideUnitCircle * radius;

        float dis = Vector3.Distance(randomPos, Vector3.zero);
        float per = radius / dis;

        randomPos *= per;

        randomPos += GameManager.Instance.Fort.position;

        return randomPos;
    }
    //나치군 사병 소환
    public IEnumerator StartNichiSoldierSpawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000000).EnemySpawnCycle;
        float elapseTime = 0f;
        //elapsetime이 스폰사이클과 같아지면, 몬스터를 스폰하고 다시 elapsetime을 0으로 초기화
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(2).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //코루틴에서의 null = 1프레임
        }
    }
    //나치 저격수병 소환
    public IEnumerator StartNichiSniper_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000010).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime이 스폰사이클과 같아지면, 몬스터를 스폰하고 다시 elapsetime을 0으로 초기화
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(1).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //코루틴에서의 null = 1프레임
        }
    }
    //나치군 포병 소환
    public IEnumerator StartNichiGunner_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000020).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime이 스폰사이클과 같아지면, 몬스터를 스폰하고 다시 elapsetime을 0으로 초기화
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(0).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //코루틴에서의 null = 1프레임
        }
    }
}