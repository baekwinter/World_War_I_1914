using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        // UIManager �ν��Ͻ��� �̹� �����ϸ�, ���� ������ ��ü�� �ı�
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // UIManager �ν��Ͻ��� ������, �� ��ü�� �Ҵ��ϰ� �ı����� �ʵ��� ����
        instance = this;
        DontDestroyOnLoad(gameObject);

        // ���� ����� ������ ȣ��� �޼ҵ带 �̺�Ʈ�� ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // ��ü�� �ı��� ��, �̺�Ʈ���� �޼ҵ带 ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ���� �ε�� ������ ȣ��Ǵ� �޼ҵ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� ���� �ʿ��� UI ������ ���⿡�� �մϴ�.
        switch (scene.name)
        {
            case "Intro_Scene":
                // Intro ���� �´� UI ����
                break;
            case "Lobby_Scene":
                // Lobby ���� �´� UI ����
                break;
            case "ChapterSelect_Scene":
                // ChapterSelect ���� �´� UI ����
                break;
            case "Chapter1_Battle_Scene":
                // Chapter1_Battle ���� �´� UI ����
                break;
                // �߰������� �ٸ� ���� ���� ������ ����
        }
    }

    // UI ���� �޼��带 ���⿡ �߰��մϴ�. ���� ���, Ư�� UI �г��� ���ų� �ݴ� �޼��� ���� ������ �� �ֽ��ϴ�.
}
