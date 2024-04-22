using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageButton : MonoBehaviour
{
    [SerializeField] private int _stageId;
    [SerializeField] private Button _stageButton;
    
    private void Start()
    {
        //����� �������� ���̵� ������ �ְ�, �� ��� ��ư�� �������� �����Ŵ����� �ִ� �������� ���̵��� �ٲ��ֵ��� ��
        _stageButton.onClick.AddListener(() => InfoManager.Instance.SettingSelectStageId(_stageId));
    }

}
