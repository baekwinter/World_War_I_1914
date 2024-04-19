using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Awake()
    {
        // 이 오브젝트가 씬 전환시에도 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    // Intro_Scene에서 사용할 메소드
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }

    // Lobby_Scene에서 사용할 메소드
    public void LoadChapterSelectScene()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // ChapterSelect_Scene에서 사용할 메소드
    public void LoadStage1MountainArea()
    {
        // ChapterSelect_Scene 내에서 특정 UI Panel을 열기 위한 로직
        GameObject chapter1SelectPanel = GameObject.Find("Chapter1_SelectPanel");
        if (chapter1SelectPanel != null)
        {
            chapter1SelectPanel.SetActive(true);
        }
    }

    // ChapterSelect_Scene 내의 StageFlag1_x 버튼에 할당할 메소드
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }
}
