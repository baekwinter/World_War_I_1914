using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

[System.Serializable]
[CreateAssetMenu(fileName = "New Speaker", menuName = "Speaker/Create New Speaker")]
public class Speaker : ScriptableObject
{
    public bool isPlayer;
    public string speaker_name;
    public Sprite[] standing_sprites;
}
public class DialogueSystem : MonoBehaviour
{
    [Header("Left Panel")]
    [SerializeField] private GameObject left_Panel;
    [SerializeField] private Text left_name_text;
    [SerializeField] private Image left_standing_image;

    [Header("Right Panel")]
    [SerializeField] private GameObject right_Panel;
    [SerializeField] private Text right_name_text;
    [SerializeField] private Image right_standing_image;

    [Header("ETC")]
    [SerializeField] private GameObject etc;
    public Dialogue[] dialogues;
    [SerializeField] private Text dialogue_text;
    public List<EachDialogue> nowDialogueList;
    public Button left_buttons;
    public Button right_buttons;
    public Button end_button;

    int diaIndex;
    private string fullText;
    private string currentText = "";
    private Text typingText;
    public float typingSpeed = 0.05f;


    void Start()
    {
        //end_button.gameObject.SetActive(false);
        //left_Panel.gameObject.SetActive(false);
        //right_Panel.gameObject.SetActive(false);
        //etc.SetActive(false);
    }

    public void StartSpeak()
    {
        diaIndex = 0; // 대사 인덱스 초기화
        left_buttons.gameObject.SetActive(false); // 첫 대사에는 이전 대사가 존재하지 않으므로, 이전 대사 출력 버튼을 없앤다.
        etc.SetActive(true);
        Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText); // 현재 인덱스의 발화자, 대사, 표정을 전달한다.
    }

    public void NextSpeak() // 다음 대사 출력
    {
        //end_button.gameObject.SetActive(false);
        //left_buttons.gameObject.SetActive(true); // 이전 대사를 출력해주는 버튼을 활성화한다. 

        diaIndex++; // 대사 인덱스 증가
        Debug.Log(diaIndex);
        if (nowDialogueList.Count > diaIndex)
            Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText);

        else { EndDialogue(); }
        //if (diaIndex >= nowDialogueList.Count - 1) // if It is last dialogue, Not active Right arrow button. 
        //{
        //    right_buttons.gameObject.SetActive(false); // 마지막 대사인 경우 다음 대사 출력 버튼을 비활성화하고,
        //    end_button.gameObject.SetActive(true); // 대화 마치기 버튼을 활성화한다.
        //}
    }

    public void Print()
    {
        Debug.Log("버튼 클릭");
    }

    public void PrevSpeak()
    {
        right_buttons.gameObject.SetActive(true);
        diaIndex--;
        Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText);
        if (diaIndex == 0) // if It is 0th dialogue, Not active Left arrow button 
        {
            left_buttons.gameObject.SetActive(false); // 첫 대사인 경우 이전 대사 출력 버튼을 비활성화한다.
        }
    }


    void Speak(string speaker, string dia) // 대사 출력 함수
    {
        currentText = ""; // Empty text. 타이핑 효과를 위해 처음엔 공백을 넣어준다.
        fullText = dia; // 전체 대사를 저장한다.
        //if (speaker.isPlayer)
        //    LeftSpeakerActive(speaker, dia); // 플레이어인 경우 왼쪽에서 대사 출력
        //else RightSpeakerActive(speaker, dia); // 다른 인물의 경우 오른쪽에서 대사 출력

        switch (speaker)
        {
            case "앤(유진)":
                LeftSpeakerActive(speaker, dia);
                break;

            case "디디":
                RightSpeakerActive(speaker, dia);
                break;
        }
    }

    void LeftSpeakerActive(string speaker, string dia)
    {
        right_Panel.SetActive(false);
        left_Panel.SetActive(true);
        left_name_text.text = speaker;
        typingText = dialogue_text;
        StartCoroutine(ShowText());

        //if (speaker.standing_sprites.Length > 0) // 배열이 비어있지 않은지 확인
        //{
        //    left_standing_image.sprite = speaker.standing_sprites[0]; // 첫 번째 스프라이트를 가져옴
        //}
        //else
        //{
        //    left_standing_image.sprite = null; // 스프라이트가 없으면 null로 설정
        //}
    }

    void RightSpeakerActive(string speaker, string dia)
    {
        left_Panel.SetActive(false);
        right_Panel.SetActive(true);
        right_name_text.text = speaker;
        typingText = dialogue_text;
        StartCoroutine(ShowText());
        //if (speaker.standing_sprites.Length > 0) // 배열이 비어있지 않은지 확인
        //{
        //    right_standing_image.sprite = speaker.standing_sprites[0]; // 첫 번째 스프라이트를 가져옴
        //}
        //else
        //{
        //    right_standing_image.sprite = null; // 스프라이트가 없으면 null로 설정
        //}
    }

    public void EndDialogue() // 대화 종료 시 모두 비활성화
    {
        //left_Panel.gameObject.SetActive(false);
        //right_Panel.gameObject.SetActive(false);
        //etc.SetActive(false);

        //// 대화 종료 시 이미지를 제거
        //left_standing_image.sprite = null;
        //right_standing_image.sprite = null;

        SceneLoader.Instance.LoadLobbyScene();
        Debug.Log("대화 종료");
    }

    IEnumerator ShowText() // 타이핑 효과를 위한 코루틴
    {
        int index = diaIndex;

        for (int i = 0; i <= fullText.Length; i++)
        {
            // 코루틴이 시작될 때의 diaIndex 값과 현재 diaIndex 값이 다르면 중지
            if (index != diaIndex)
            {
                yield break;
            }

            currentText = fullText.Substring(0, i);
            typingText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

}