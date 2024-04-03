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
        Debug.Log("오늘도 상민이가 격하게 아주 매우 많이 보고싶다,");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" 눌렸음");
            PoolManager.Instance.Get(0);
        }
    }
}
