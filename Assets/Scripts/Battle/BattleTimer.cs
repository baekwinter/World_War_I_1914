using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    public int timeLeft = 180; // �� ������ �ð� ����
    public TMP_Text timeText; // UI�� �ð��� ǥ���� Text ������Ʈ

    //�Լ��� ���ؼ� ������ �ϵ��� �ϰ�, �� ������������ ������ �ǰԲ� ���鵵��,,
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    void Update()
    {
        timeText.text = (timeLeft / 60) + ":" + (timeLeft % 60).ToString("00");
    }

    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        // �ð��� �� �Ǹ� ������ ����
        // 1.����Ŭ����â (�����۵��� �����ִ� â)
    }
}
