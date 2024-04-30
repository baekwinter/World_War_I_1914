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
        diaIndex = 0; // ��� �ε��� �ʱ�ȭ
        left_buttons.gameObject.SetActive(false); // ù ��翡�� ���� ��簡 �������� �����Ƿ�, ���� ��� ��� ��ư�� ���ش�.
        etc.SetActive(true);
        Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText); // ���� �ε����� ��ȭ��, ���, ǥ���� �����Ѵ�.
    }

    public void NextSpeak() // ���� ��� ���
    {
        //end_button.gameObject.SetActive(false);
        //left_buttons.gameObject.SetActive(true); // ���� ��縦 ������ִ� ��ư�� Ȱ��ȭ�Ѵ�. 

        diaIndex++; // ��� �ε��� ����
        Debug.Log(diaIndex);
        if (nowDialogueList.Count > diaIndex)
            Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText);

        else { EndDialogue(); }
        //if (diaIndex >= nowDialogueList.Count - 1) // if It is last dialogue, Not active Right arrow button. 
        //{
        //    right_buttons.gameObject.SetActive(false); // ������ ����� ��� ���� ��� ��� ��ư�� ��Ȱ��ȭ�ϰ�,
        //    end_button.gameObject.SetActive(true); // ��ȭ ��ġ�� ��ư�� Ȱ��ȭ�Ѵ�.
        //}
    }

    public void Print()
    {
        Debug.Log("��ư Ŭ��");
    }

    public void PrevSpeak()
    {
        right_buttons.gameObject.SetActive(true);
        diaIndex--;
        Speak(nowDialogueList[diaIndex].speaker, nowDialogueList[diaIndex].dialogueText);
        if (diaIndex == 0) // if It is 0th dialogue, Not active Left arrow button 
        {
            left_buttons.gameObject.SetActive(false); // ù ����� ��� ���� ��� ��� ��ư�� ��Ȱ��ȭ�Ѵ�.
        }
    }


    void Speak(string speaker, string dia) // ��� ��� �Լ�
    {
        currentText = ""; // Empty text. Ÿ���� ȿ���� ���� ó���� ������ �־��ش�.
        fullText = dia; // ��ü ��縦 �����Ѵ�.
        //if (speaker.isPlayer)
        //    LeftSpeakerActive(speaker, dia); // �÷��̾��� ��� ���ʿ��� ��� ���
        //else RightSpeakerActive(speaker, dia); // �ٸ� �ι��� ��� �����ʿ��� ��� ���

        switch (speaker)
        {
            case "��(����)":
                LeftSpeakerActive(speaker, dia);
                break;

            case "���":
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

        //if (speaker.standing_sprites.Length > 0) // �迭�� ������� ������ Ȯ��
        //{
        //    left_standing_image.sprite = speaker.standing_sprites[0]; // ù ��° ��������Ʈ�� ������
        //}
        //else
        //{
        //    left_standing_image.sprite = null; // ��������Ʈ�� ������ null�� ����
        //}
    }

    void RightSpeakerActive(string speaker, string dia)
    {
        left_Panel.SetActive(false);
        right_Panel.SetActive(true);
        right_name_text.text = speaker;
        typingText = dialogue_text;
        StartCoroutine(ShowText());
        //if (speaker.standing_sprites.Length > 0) // �迭�� ������� ������ Ȯ��
        //{
        //    right_standing_image.sprite = speaker.standing_sprites[0]; // ù ��° ��������Ʈ�� ������
        //}
        //else
        //{
        //    right_standing_image.sprite = null; // ��������Ʈ�� ������ null�� ����
        //}
    }

    public void EndDialogue() // ��ȭ ���� �� ��� ��Ȱ��ȭ
    {
        //left_Panel.gameObject.SetActive(false);
        //right_Panel.gameObject.SetActive(false);
        //etc.SetActive(false);

        //// ��ȭ ���� �� �̹����� ����
        //left_standing_image.sprite = null;
        //right_standing_image.sprite = null;

        SceneLoader.Instance.LoadLobbyScene();
        Debug.Log("��ȭ ����");
    }

    IEnumerator ShowText() // Ÿ���� ȿ���� ���� �ڷ�ƾ
    {
        int index = diaIndex;

        for (int i = 0; i <= fullText.Length; i++)
        {
            // �ڷ�ƾ�� ���۵� ���� diaIndex ���� ���� diaIndex ���� �ٸ��� ����
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