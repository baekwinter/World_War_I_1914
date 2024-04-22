using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : SingletonBase<InfoManager>
{
    public int SelectStageId; // 각 챕터별 스테이지 아이디

    public void SettingSelectStageId(int selectStageId_)
    {
        SelectStageId = selectStageId_;
    }
}
