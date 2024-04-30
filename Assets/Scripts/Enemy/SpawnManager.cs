using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Contains;
public class SpawnManager : MonoBehaviour
{
    public Tilemap tilemap; // Tilemap ������Ʈ ���� �߰�
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    public Transform fort; // �÷��̾��� ��ġ�� ��Ÿ���� Transform

    private void Start()
    {
        StartEnemySpawn();
    }

    private bool IsWithinTilemapBounds(Vector3 position)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        return tilemap.cellBounds.Contains(cellPosition);
    }

    public Vector3 GetRandomCircleSpawnPosition(Vector3 playerPosition, float radius)
    {
        Vector3 randomPos = Vector3.zero;
        bool isValidPosition = false;
        int attempts = 0; // �õ� Ƚ���� �����ϱ� ���� ����
        int maxAttempts = 50; // �ִ� �õ� Ƚ��

        do
        {
            if (attempts > maxAttempts) // �ִ� �õ� Ƚ���� �ʰ��� ���
            {
                //Debug.LogError("��ȿ�� ���� ��ġ�� ã�� �� ����. ���� ������ ������ Ȯ���ϼ���.");
                return Vector3.zero; // ���� �� Vector3.zero ��ȯ
            }

            Vector2 offset = Random.insideUnitCircle * radius;
            randomPos = new Vector3(playerPosition.x + offset.x, playerPosition.y + offset.y, 0);

            if (IsWithinTilemapBounds(randomPos))
            {
                isValidPosition = CheckValidSpawnPosition(randomPos);
            }

            attempts++; // �õ� Ƚ�� ����
        }
        while (!isValidPosition);

        return randomPos;
    }


    private bool CheckValidSpawnPosition(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            return false;
        }

        Collider2D hitCollider = Physics2D.OverlapCircle(position, 0.5f);
        if (hitCollider != null)
        {
            return false;
        }

        // Ÿ�ϸ� �� Ư�� ��ġ�� Ÿ���� �����ϴ��� Ȯ��
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile == null) // "BackGround" ���̾ ���� Ÿ���� ���ٸ�
        {
            return false; // �ش� ��ġ�� ��ȿ�� ���� ��ġ�� �ƴ�
        }

        return true;
    }
    public void StartEnemySpawn()
    {
        StageData stageData = DataBase.Stage.Get(InfoManager.Instance.SelectStageId);
        EnemyGroupData enemyGroupData = DataBase.EnemyGroup.Get(stageData.EnemyGroupId);

        for (int i = 0; i < enemyGroupData.GroupEnemyNum; i++)
        {
            switch (i)
            {
                case 0:
                    StartCoroutine(StartEnemyGroupSpawn(enemyGroupData.EnemyGroupId0));
                    break;
                case 1:
                    StartCoroutine(StartEnemyGroupSpawn(enemyGroupData.EnemyGroupId1));
                    break;
                case 2:
                    StartCoroutine(StartEnemyGroupSpawn(enemyGroupData.EnemyGroupId2));
                    break;
            }

        }
    }
    public IEnumerator StartEnemyGroupSpawn(int enemyId_)
    {
        float spawnCycle = DataBase.Enemy.Get(enemyId_).EnemySpawnCycle;
        float elapseTime = 0f;
        int prefabNum = 0;
        switch (enemyId_)
        {
            case 10000000:
                prefabNum = 0;
                break;
            case 10000010:
                prefabNum = 1;
                break;
            case 10000020:
                prefabNum = 2;
                break;

        }
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(prefabNum).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null;
        }
    }
    // ��ġ�� �纴, ���ݼ���, ���� ��ȯ �ڷ�ƾ�� �Ʒ��� ���� ����
    // ��ġ�� �纴 ��ȯ
    public IEnumerator StartNichiSoldierSpawn()
    {
        float spawnCycle = DataBase.Enemy.Get(EnemyContains.Nichi_Soldier).EnemySpawnCycle;
        float elapseTime = 0f;
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(2).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null;
        }
    }
    // ��ġ ���ݼ��� �� ���� ��ȯ �ڷ�ƾ�� �����ϰ� ����...
    //��ġ ���ݼ��� ��ȯ
    public IEnumerator StartNichiSniper_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(EnemyContains.Nichi_Sniper).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(1).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null; //�ڷ�ƾ������ null = 1������
        }
    }
    //��ġ�� ���� ��ȯ
    public IEnumerator StartNichiGunner_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(EnemyContains.Nichi_Gunner).EnemySpawnCycle;
        float elapseTime = 0f;
        //elapsetime�� ��������Ŭ�� ��������, ���͸� �����ϰ� �ٽ� elapsetime�� 0���� �ʱ�ȭ
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(0).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null; //�ڷ�ƾ������ null = 1������
        }
    }
}
