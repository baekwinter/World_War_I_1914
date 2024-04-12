using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour 
{
    public static PoolManager Instance = null;

    //..������ ������ ����(�迭)
    public GameObject[] prefabs;

    // Ǯ ����� ����Ʈ �ʿ�!!
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
        // 1. �ٸ� ��ũ��Ʈ���� Get�� �� ���, ������ Ǯ�� ��� �ִ�(��Ȱ��ȭ��) ���ӿ�����Ʈ ���� 

        foreach (GameObject item  in pools[index])
        {
            if (!item.activeSelf)
            {
                // 2. ���࿡ �ش� �κ��� �߰����� ���, �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        } 
        // 3. ��ã�Ҵٸ�?
        if (!select) 
        {
            //-> ���Ӱ� �����Ͽ� select ������ �Ҵ�

            // poolManager �θ�� ����
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select); //Ǯ�� ����ϱ�

        }


        return select;
    }

    public void Test()
    {
        Debug.Log("dqd");
    }
        
}
