using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : SingletonBase<InfoManager>
{
    public int SelectStageId; // �� é�ͺ� �������� ���̵�

    public void SettingSelectStageId(int selectStageId_)
    {
        SelectStageId = selectStageId_;
    }
}
