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

    // ChapterSelect_Scene에서 Stage1_산악지대를 선택했을 때 호출될 메소드
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }

    // Chapter1_Battle_Scene에서 GameOverPopUp의 ExitBtn을 눌렀을 때 호출될 메소드
    public void LoadChapterSelectSceneFromGameOver()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // Chapter1_Battle_Scene에서 GameClear 패널의 버튼을 눌렀을 때 호출될 메소드
    public void LoadChapterSelectSceneFromGameClear()
    {
        SceneManager.LoadScene("ChapterSelect_Scene");
    }

    // Lobby_Scene에서 Exit 버튼을 눌렀을 때 Intro_Scene으로 돌아가는 메소드
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro_Scene");
    }
}
