using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        // �� ������Ʈ�� �� ��ȯ�ÿ��� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);
    }

    // Intro_Scene���� ����� �޼ҵ�
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }

    // Lobby_Scene���� ����� �޼ҵ�
    public void LoadChapterSelectScene()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // ChapterSelect_Scene���� ����� �޼ҵ�
    public void LoadStage1MountainArea()
    {
        // ChapterSelect_Scene ������ Ư�� UI Panel�� ���� ���� ����
        GameObject chapter1SelectPanel = GameObject.Find("Chapter1_SelectPanel");
        if (chapter1SelectPanel != null)
        {
            chapter1SelectPanel.SetActive(true);
        }
    }

    // ChapterSelect_Scene ���� StageFlag1_x ��ư�� �Ҵ��� �޼ҵ�
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }
}
