using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [NonSerialized] public DialogueSystem dialogueSystem;
    public TextMeshProUGUI Tmp;

    [Serializable]
    public class EachDialogue // 하나의 대사에 필요한 요소들이 담긴 클래스.
    {
        public int diaID; // 필요한 대사를 찾기 위해 필요한 값. 인스펙터 창에서 지정하면 이 값을 읽고 필요한 대화가 해당 대화인지 구별할 수 있다.
        public string speaker;
        [TextArea()] public string dialogueText;

        public Speaker GetSpeaker()
        {
            // 문자열을 Speaker 객체로 매핑
            return Resources.Load<Speaker>("Speaker/" + speaker);
        }
    }

    public class DialogueContainer // 대사 모음
    {
        public List<EachDialogue> dialogueList; // 
    }

    public DialogueContainer dialogueContainer;

    public EachDialogue[] thisIdDialogues; // 지정한 대화ID가 일치하는 대사들만 모아놓는다. 이것을 DialogueSystem에 전달.

    // 텍스트에셋을 텍스트로 변환하는 부분
    public TextAsset dialogueJson;
    public int dialogueID; // 이곳에 지정한 대화 ID로 대사를 찾는다.


    void Start()
    {
        dialogueSystem = GameObject.Find("Canvas_Dialogue").GetComponent<DialogueSystem>(); // DialogueSystem 참조
        TextAsset dialogueDBRequest = Resources.Load<TextAsset>("Dialogue"); // 대화 데이터를 로드합니다.
        if (dialogueDBRequest == null)
        {
            Debug.LogError("Dialogue data file not found."); // 대화 데이터 파일을 찾을 수 없는 경우 오류 메시지를 출력합니다.
            return;
        }

        string jsonString = "{ \"dialogueList\": " + dialogueDBRequest.text + "}";
        Debug.Log(jsonString);
        dialogueContainer = JsonUtility.FromJson<DialogueContainer>(jsonString); // JSON 데이터를 DialogueContainer 객체로 역직렬화합니다.

        // dialogueID++; // 이 부분은 주석 처리하여 대화 ID를 1부터 시작하도록 합니다.
        FindNextDialogue(); // 다음 대화를 찾는 메서드를 호출합니다.
    }

    void FindNextDialogue()
    {
        // 대화 ID를 기반으로 다음 대화를 찾습니다.
        // 다음 대화 ID를 dialogueID로 설정하고, 해당 대화를 출력합니다.
        FindDialogueByID(dialogueID);
    }

    void FindDialogueByID(int targetDiaID)
    {
        bool dialogueFound = false; // 대화를 찾았는지 여부를 나타내는 플래그입니다.

        // 대화 ID가 1부터 시작하도록 수정합니다.
        for (int i = 0; i < dialogueContainer.dialogueList.Count; i++)
        {
            if (dialogueContainer.dialogueList[i].diaID == targetDiaID)
            {
                // 대화 ID가 일치하는 대화를 찾으면 해당 대화를 출력합니다.
                Tmp.text = dialogueContainer.dialogueList[i].dialogueText;
                dialogueFound = true;
                break; // 대화를 찾았으므로 루프를 종료합니다.
            }
        }

        if (!dialogueFound)
        {
            Debug.LogError("Dialogue with ID " + targetDiaID + " not found."); // 대화를 찾을 수 없는 경우 오류 메시지를 출력합니다.
        }
    }



    // // 대화 ID에 해당하는 대화를 찾는 함수
    // private void FindDialogueByID(int targetDiaID)
    // {
    //     int i;
    //     int j = 0;
    //     Debug.Log(dialogueContainer.dialogueList.Count);
    //     for (i = 0; i < dialogueContainer.dialogueList.Count; i++)
    //     {
    //         if (dialogueContainer.dialogueList[i].diaID == targetDiaID)
    //         {
    //             break; // 대화 시작 인덱스 찾기
    //         }
    //     }
    //     
    //     while (dialogueContainer.dialogueList[i + j].diaID == targetDiaID) j++; // 대화 끝 인덱스 찾기 i 값이
    //     thisIdDialogues = new EachDialogue[j];
    //     for (j = 0; dialogueContainer.dialogueList[i + j].diaID == targetDiaID; j++)
    //     {
    //         thisIdDialogues[j] = dialogueContainer.dialogueList[j + i];
    //         // 만약 대사에 "{}"가 포함된다면, 해당 텍스트를 플레이어가 지정한 플레이어 이름으로 변환(수정)
    //         thisIdDialogues[j].dialogueText = thisIdDialogues[j].dialogueText
    //             .Replace("{}", Resources.Load<Speaker>("Speaker/Player").speaker_name);
    //     }
    // }

    // Dialogue를 시작하고 싶을 땐 이 함수만 불러오면 된다.
    public void DialogueStart()
    {
        FindDialogueByID(dialogueID);
        dialogueSystem.nowDialogueList = thisIdDialogues;
        dialogueSystem.StartSpeak();
    }
}