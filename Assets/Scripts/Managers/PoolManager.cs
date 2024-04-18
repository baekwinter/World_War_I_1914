using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // PoolManager�� �ν��Ͻ��� �̱������� ����
    public static PoolManager Instance = null;

    // �������� ������ �迭
    public GameObject[] prefabs;

    // ��ü Ǯ�� ������ ����Ʈ �迭
    private List<GameObject>[] pools;

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
        }

        // ������ �迭 ũ�⸸ŭ Ǯ ����Ʈ �ʱ�ȭ
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

        // Ǯ �ʱ�ȭ: �ʿ��� ��ü�� �̸� �����Ͽ� Ǯ�� �߰�
        InitializePools();
    }

    private void InitializePools()
    {
        // �� Ǯ���� �ʱ⿡ ������ ��ü �� ����
        int initialCount = 10; // ���� ��

        for (int i = 0; i < prefabs.Length; i++)
        {
            for (int j = 0; j < initialCount; j++)
            {
                GameObject obj = Instantiate(prefabs[i], transform);
                obj.SetActive(false); // ��ü�� ��Ȱ��ȭ ���·� ����
                pools[i].Add(obj);
            }
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // Ǯ���� ��Ȱ��ȭ�� ��ü�� ã��
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                break; // ��Ȱ��ȭ�� ��ü�� ã���� �ݺ� ����
            }
        }

        // Ǯ�� ��Ȱ��ȭ�� ��ü�� ���ٸ� ���ο� ��ü ����
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); // ���� ������ ��ü�� Ǯ�� �߰�
        }

        // ��ü�� Ȱ��ȭ�ϰ� ��ȯ
        select.SetActive(true);
        return select;
    }

    // ��ü�� Ǯ�� ��ȯ�ϴ� �޼���
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false); // ��ü�� ��Ȱ��ȭ
        // �ʿ��� ���, ���⼭ ��ü�� ��ġ�� �ʱ�ȭ�ϰų�, �ٸ� �ʱ�ȭ ������ �߰��� �� �ֽ��ϴ�.
    }
}
