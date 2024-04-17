using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //��ȯ�� ������ ������
    public GameObject enemyPrefab;
   // ���͸� ��ȯ�� ��ġ ���
    public List<Transform> spawnPoints;

   // ���͸� ��ȯ�� ����
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
    //��ġ�� �纴 ��ȯ
    public IEnumerator StartNichiSoldierSpawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000000).EnemySpawnCycle;
        float elapseTime = 0f;
        //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(2).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //�ڷ�ƾ������ null = 1������
        }
    }
    //��ġ ���ݼ��� ��ȯ
    public IEnumerator StartNichiSniper_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000010).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(1).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //�ڷ�ƾ������ null = 1������
        }
    }
    //��ġ�� ���� ��ȯ
    public IEnumerator StartNichiGunner_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000020).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                PoolManager.Instance.Get(0).transform.position = GetRandomCircleSpawnPosition(10);
                elapseTime = 0;
            }

            yield return null; //�ڷ�ƾ������ null = 1������
        }
    }
}