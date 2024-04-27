using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    [SerializeField] private int _stageId;
    public int timeLeft; // �� ������ �ð� ����
    private StageData _stageData;
    public TMP_Text timeText; // UI�� �ð��� ǥ���� Text ������Ʈ

    private void Awake()
    {
        _stageId = InfoManager.Instance.SelectStageId;
        _stageData = DataBase.Stage.Get(_stageId);

    }

    //�Լ��� ���ؼ� ������ �ϵ��� �ϰ�, �� ������������ ������ �ǰԲ� ���鵵��,,
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
        // �ð��� �� �Ǹ� ������ ����

        // 1.����Ŭ����â (�����۵��� �����ִ� â)
        UIManager.Instance.ShowPopup<GameOverPopup>();
    }
}
