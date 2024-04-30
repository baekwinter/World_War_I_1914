using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance = null;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            if (Instance != this)
                // �� ������Ʈ�� �� ��ȯ�ÿ��� �ı����� �ʵ��� ����
                DontDestroyOnLoad(gameObject);
        }
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

    // ChapterSelect_Scene���� Stage1_������븦 �������� �� ȣ��� �޼ҵ�
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }

    // Chapter1_Battle_Scene���� GameOverPopUp�� ExitBtn�� ������ �� ȣ��� �޼ҵ�
    public void LoadChapterSelectSceneFromGameOver()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // Chapter1_Battle_Scene���� GameClear �г��� ��ư�� ������ �� ȣ��� �޼ҵ�
    public void LoadChapterSelectSceneFromGameClear()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // Lobby_Scene���� Exit ��ư�� ������ �� Intro_Scene���� ���ư��� �޼ҵ�
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro_Scene");
    }
    //Ʃ�丮��� �ε�
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");

    }
}