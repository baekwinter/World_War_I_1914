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
        //깃발은 스테이지 아이디를 가지고 있고, 그 깃발 버튼을 눌렀을때 인포매니저에 있는 스테이지 아이디값을 바꿔주도록 함
        _stageButton.onClick.AddListener(() => InfoManager.Instance.SettingSelectStageId(_stageId));
    }

}
