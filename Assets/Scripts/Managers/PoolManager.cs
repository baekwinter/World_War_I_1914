using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour 
{
    public static PoolManager Instance = null;

    //..프리팹 저장할 변수(배열)
    public GameObject[] prefabs;

    // 풀 담당할 리스트 필요!!
    List<GameObject>[] pools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        } 
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // 1. 다른 스크립트에서 Get을 쓸 경우, 선택한 풀의 놀고 있는(비활성화된) 게임오브젝트 접근 

        foreach (GameObject item  in pools[index])
        {
            if (!item.activeSelf)
            {
                // 2. 만약에 해당 부분을 발견했을 경우, 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        } 
        // 3. 못찾았다면?
        if (!select) 
        {
            //-> 새롭게 생성하여 select 변수에 할당

            // poolManager 부모로 설정
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select); //풀에 등록하기

        }


        return select;
    }

    public void Test()
    {
        Debug.Log("dqd");
    }
        
}
