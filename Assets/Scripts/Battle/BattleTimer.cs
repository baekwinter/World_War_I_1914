using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    public int timeLeft = 180; // �� ������ �ð� ����
    public Text timeText; // UI�� �ð��� ǥ���� Text ������Ʈ

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
    }
}
