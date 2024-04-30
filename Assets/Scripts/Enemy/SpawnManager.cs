using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Contains;
public class SpawnManager : MonoBehaviour
{
    public Tilemap tilemap; // Tilemap 컴포넌트 참조 추가
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    public Transform fort; // 플레이어의 위치를 나타내는 Transform

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
        int attempts = 0; // 시도 횟수를 추적하기 위한 변수
        int maxAttempts = 50; // 최대 시도 횟수

        do
        {
            if (attempts > maxAttempts) // 최대 시도 횟수를 초과한 경우
            {
                //Debug.LogError("유효한 스폰 위치를 찾을 수 없음. 스폰 가능한 영역을 확인하세요.");
                return Vector3.zero; // 실패 시 Vector3.zero 반환
            }

            Vector2 offset = Random.insideUnitCircle * radius;
            randomPos = new Vector3(playerPosition.x + offset.x, playerPosition.y + offset.y, 0);

            if (IsWithinTilemapBounds(randomPos))
            {
                isValidPosition = CheckValidSpawnPosition(randomPos);
            }

            attempts++; // 시도 횟수 증가
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

        // 타일맵 내 특정 위치에 타일이 존재하는지 확인
        Vector3Int cellPosition = tilemap.WorldToCell(position);
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile == null) // "BackGround" 레이어에 속한 타일이 없다면
        {
            return false; // 해당 위치는 유효한 스폰 위치가 아님
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
    // 나치군 사병, 저격수병, 포병 소환 코루틴은 아래와 같이 수정
    // 나치군 사병 소환
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
    // 나치 저격수병 및 포병 소환 코루틴도 유사하게 수정...
    //나치 저격수병 소환
    public IEnumerator StartNichiSniper_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(EnemyContains.Nichi_Sniper).EnemySpawnCycle;

        float elapseTime = 0f;
        //elapsetime이 스폰사이클과 같아지면, 몬스터를 스폰하고 다시 elapsetime을 0으로 초기화
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(1).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null; //코루틴에서의 null = 1프레임
        }
    }
    //나치군 포병 소환
    public IEnumerator StartNichiGunner_Spawn()
    {
        float spawnCycle = DataBase.Enemy.Get(EnemyContains.Nichi_Gunner).EnemySpawnCycle;
        float elapseTime = 0f;
        //elapsetime이 스폰사이클과 같아지면, 몬스터를 스폰하고 다시 elapsetime을 0으로 초기화
        while (true)
        {
            elapseTime += Time.deltaTime;
            if (elapseTime >= spawnCycle)
            {
                Vector3 spawnPosition = GetRandomCircleSpawnPosition(fort.position, 10);
                PoolManager.Instance.Get(0).transform.position = spawnPosition;
                elapseTime = 0;
            }

            yield return null; //코루틴에서의 null = 1프레임
        }
    }
}
