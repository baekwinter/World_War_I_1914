using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject chapter1SelectPanel; // Chapter1_SelectPanel에 대한 참조
    [SerializeField]
    private GameObject stageSelectPanel; // StageSelect 패널에 대한 참조

    void Awake()
    {
        // 이 오브젝트가 씬 전환시에도 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    // Select_Stage의 Stage1_산악지대를 선택했을 때 호출될 메소드
    public void ActivateChapter1SelectPanel()
    {
        // StageSelect 패널을 활성화
        if (stageSelectPanel != null)
        {
            stageSelectPanel.SetActive(true);
        }

        // Chapter1_SelectPanel을 활성화
        if (chapter1SelectPanel != null)
        {
            chapter1SelectPanel.SetActive(true);
        }
    }

    // StageFlags (StageFlg1_1, StageFlg1_2, StageFlg1_3) 중 하나를 눌렀을 때 호출될 메소드
    public void LoadChapter1BattleScene()
    {
        SceneManager.LoadScene("Chapter1_Battle_Scene");
    }
}
