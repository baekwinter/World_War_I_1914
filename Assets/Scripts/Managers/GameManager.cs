using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public PoolManager pool;
    public Transform Fort;
    public GameObject GameOver; // ���� ���� ȭ�� ������Ʈ

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ߺ� ������ ���� ��ü�� ����
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // �� ��ȯ �ÿ��� ���� �Ŵ����� ����
        }
    }



    public void ShowGameClear()
    {
        GameOver.SetActive(true); //����Ŭ���� ȭ�� Ȱ��ȭ
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true); // ���� ���� ȭ�� Ȱ��ȭ
    }
}
