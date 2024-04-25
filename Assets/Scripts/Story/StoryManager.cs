using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ���ӽ����̽� ���

public class StoryManager : MonoBehaviour
{
    public TextMeshProUGUI storyText; // TextMeshProUGUI ������Ʈ ���
    public Button nextButton;

    private string[] storyTexts = { "����� �������� ������ �ΰ� �־����ϴ�. ��ȭ�ο� �ϻ��� ���а� �������, �� ������ ������ ȥ�� �ӿ��� ������ ���� �ο�� �־����ϴ�.", "��ҿ� ���� ����� �ϰ� ������ ���ƿ� ��뿡 �� �������� ���� ������ ���� \"World War I: 1914\"�� �����Ͽ���.", "��,,��,,??", "�� �Ͼ� ȭ��� �Բ� ������ �����ϴ� ����, �� �� ������ ����, �� ���ΰ� ������ ���ع����� ���Ҵ�." };
    private int currentIndex = 0;

    void Start()
    {
        // �ʱ� �ؽ�Ʈ ����
        storyText.text = storyTexts[currentIndex];

        // ��ư Ŭ�� �̺�Ʈ ����
        nextButton.onClick.AddListener(DisplayNextStoryText);
    }

    void DisplayNextStoryText()
    {
        // ���� �ε����� ������ �ε����� �ƴ϶��
        if (currentIndex < storyTexts.Length - 1)
        {
            // ���� ���� ǥ��
            currentIndex++;
            storyText.text = storyTexts[currentIndex];
        }
        else
        {
            // ������ �����̶�� �� �̻� ǥ���� ������ ����
            nextButton.gameObject.SetActive(false);
        }
    }
}
