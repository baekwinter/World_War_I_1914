using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParents : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.parentsUI = transform;
        //UI 라는 오브젝트를 부모로 설정
    }
}
