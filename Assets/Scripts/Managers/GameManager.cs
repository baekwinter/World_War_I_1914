using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager pool;
    public Transform Fort;
    public GameObject GameOver; // ���� ���� ȭ�� ������Ʈ
    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true); // ���� ���� ȭ�� Ȱ��ȭ
    }


}
