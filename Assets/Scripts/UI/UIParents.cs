using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParents : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.parentsUI = transform;
        //UI ��� ������Ʈ�� �θ�� ����
    }
}
