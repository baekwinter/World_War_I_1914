using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject chapter1SelectPanel; // Chapter1_SelectPanel�� ���� ����
    [SerializeField]
    private GameObject stageSelectPanel; // StageSelect �гο� ���� ����

    void Awake()
    {
        // �� ������Ʈ�� �� ��ȯ�ÿ��� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    // Select_Stage�� Stage1_������븦 �������� �� ȣ��� �޼ҵ�
    public void ActivateChapter1SelectPanel()
    {
        // StageSelect �г��� Ȱ��ȭ
        if (stageSelectPanel != null)
        {
            stageSelectPanel.SetActive(true);
        }

        // Chapter1_SelectPanel�� Ȱ��ȭ
        if (chapter1SelectPanel != null)
        {
            chapter1SelectPanel.SetActive(true);
        }
    }

    // StageFlags (StageFlg1_1, StageFlg1_2, StageFlg1_3) �� �ϳ��� ������ �� ȣ��� �޼ҵ�
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }
}
