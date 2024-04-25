using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 네임스페이스 사용

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText; // TextMeshProUGUI 컴포넌트 사용
    public Button nextButton;

    private string[] storyTexts = { "대륙은 전쟁으로 몸살을 앓고 있었습니다. 평화로운 일상은 어디론가 사라지고, 각 지역은 절망과 혼란 속에서 생존을 위해 싸우고 있었습니다.", "평소와 같이 퇴근을 하고 집으로 돌아와 기대에 찬 마음으로 사전 예약한 게임 \"World War I: 1914\"를 실행하였다.", "어,,어,,??", "새 하얀 화면과 함께 게임을 시작하는 순간, 난 이 게임의 세계, 즉 주인공 앤으로 변해버리고 말았다." };
    private int currentIndex = 0;

    void Start()
    {
        // 초기 텍스트 설정
        storyText.text = storyTexts[currentIndex];

        // 버튼 클릭 이벤트 연결
        nextButton.onClick.AddListener(DisplayNextStoryText);
    }

    void DisplayNextStoryText()
    {
        // 현재 인덱스가 마지막 인덱스가 아니라면
        if (currentIndex < storyTexts.Length - 1)
        {
            // 다음 문장 표시
            currentIndex++;
            storyText.text = storyTexts[currentIndex];
        }
        else
        {
            // 마지막 문장이라면 더 이상 표시할 내용이 없음
            nextButton.gameObject.SetActive(false);
        }
    }
}
