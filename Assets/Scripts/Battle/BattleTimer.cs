using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer : MonoBehaviour
{
    public int timeLeft = 180; // 초 단위로 시간 설정
    public Text timeText; // UI에 시간을 표시할 Text 컴포넌트

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
        // 시간이 다 되면 실행할 로직
    }
}
