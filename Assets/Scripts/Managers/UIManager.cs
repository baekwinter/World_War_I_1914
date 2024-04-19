using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        // UIManager 인스턴스가 이미 존재하면, 새로 생성된 객체를 파괴
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // UIManager 인스턴스가 없으면, 이 객체를 할당하고 파괴되지 않도록 설정
        instance = this;
        DontDestroyOnLoad(gameObject);

        // 씬이 변경될 때마다 호출될 메소드를 이벤트에 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // 객체가 파괴될 때, 이벤트에서 메소드를 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 씬이 로드될 때마다 호출되는 메소드
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬에 따라 필요한 UI 설정을 여기에서 합니다.
        switch (scene.name)
        {
            case "Intro_Scene":
                // Intro 씬에 맞는 UI 설정
                break;
            case "Lobby_Scene":
                // Lobby 씬에 맞는 UI 설정
                break;
            case "ChapterSelect_Scene":
                // ChapterSelect 씬에 맞는 UI 설정
                break;
            case "Chapter1_Battle_Scene":
                // Chapter1_Battle 씬에 맞는 UI 설정
                break;
                // 추가적으로 다른 씬에 대한 설정도 가능
        }
    }

    // UI 관련 메서드를 여기에 추가합니다. 예를 들면, 특정 UI 패널을 열거나 닫는 메서드 등을 구현할 수 있습니다.
}
