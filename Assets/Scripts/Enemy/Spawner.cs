using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private void Start()
    {
        PoolManager.Instance.Test();
    }

    void Update()
    {
        Debug.Log("���õ� ����̰� ���ϰ� ���� �ſ� ���� ����ʹ�,");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" ������");
            PoolManager.Instance.Get(0);
        }
    }
}
