using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //��ȯ�� ������ ������
    public GameObject enemyPrefab;
    // ���͸� ��ȯ�� ��ġ ���
    public List<Transform> spawnPoints;

    //���͸� ��ȯ�� ���� 
    private void Start()
    {
        PoolManager.Instance.Test();
        StartCoroutine(StartNichiSolider_Spawn());
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

    public IEnumerator StartNichiSolider_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(10000000).enemySpawnCycle;
        float elapseTime = 0f; //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
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