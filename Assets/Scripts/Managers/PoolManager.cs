using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // PoolManager의 인스턴스를 싱글톤으로 관리
    public static PoolManager Instance = null;

    // 프리팹을 저장할 배열
    public GameObject[] prefabs;

    // 객체 풀을 관리할 리스트 배열
    private List<GameObject>[] pools;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
        }

        // 프리팹 배열 크기만큼 풀 리스트 초기화
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

        // 풀 초기화: 필요한 객체를 미리 생성하여 풀에 추가
        InitializePools();
    }

    private void InitializePools()
    {
        // 각 풀마다 초기에 생성할 객체 수 설정
        int initialCount = 10; // 예시 값

        for (int i = 0; i < prefabs.Length; i++)
        {
            for (int j = 0; j < initialCount; j++)
            {
                GameObject obj = Instantiate(prefabs[i], transform);
                obj.SetActive(false); // 객체를 비활성화 상태로 유지
                pools[i].Add(obj);
            }
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 풀에서 비활성화된 객체를 찾기
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                break; // 비활성화된 객체를 찾으면 반복 종료
            }
        }

        // 풀에 비활성화된 객체가 없다면 새로운 객체 생성
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); // 새로 생성된 객체를 풀에 추가
        }

        // 객체를 활성화하고 반환
        select.SetActive(true);
        return select;
    }

    // 객체를 풀로 반환하는 메서드
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // 객체를 비활성화
        // 필요한 경우, 여기서 객체의 위치를 초기화하거나, 다른 초기화 로직을 추가할 수 있습니다.
    }
}
