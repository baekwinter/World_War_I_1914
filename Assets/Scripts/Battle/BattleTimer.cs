using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    [SerializeField] private int _stageId;
    public int timeLeft; // 초 단위로 시간 설정
    private StageData _stageData;
    public TMP_Text timeText; // UI에 시간을 표시할 Text 컴포넌트

    private void Awake()
    {
        _stageId = InfoManager.Instance.SelectStageId;
        _stageData = DataBase.Stage.Get(_stageId);

    }

    //함수를 통해서 세팅을 하도록 하고, 각 스테이지별로 적용이 되게끔 만들도록,,
    void Start()
    {
        timeLeft = _stageData.StageBattleTime;

        StartCoroutine("LoseTime");
    }

    void Update()
    {
        timeText.text = (timeLeft / 60) + ":" + (timeLeft % 60).ToString("00");
    }

    IEnumerator LoseTime()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (timeLeft > 0)
        {
            yield return waitForSeconds;
            timeLeft--;
        }
        // 시간이 다 되면 실행할 로직

        // 1.게임클리어창 (아이템들을 보여주는 창)
        UIManager.Instance.ShowPopup<GameOverPopup>();
    }
}
