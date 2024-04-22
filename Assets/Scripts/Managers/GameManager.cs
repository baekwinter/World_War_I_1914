using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public PoolManager pool;
    public Transform Fort;
    public GameObject GameOver; // 게임 오버 화면 오브젝트

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
            Destroy(this.gameObject); // 이미 인스턴스가 존재하면 중복 생성된 현재 객체를 제거
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject); // 씬 전환 시에도 게임 매니저를 유지
        }
    }



    public void ShowGameClear()
    {
        GameOver.SetActive(true); //게임클리어 화면 활성화
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true); // 게임 오버 화면 활성화
    }
}
