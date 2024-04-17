using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager pool;
    public Transform Fort;
    public GameObject GameOver; // 게임 오버 화면 오브젝트
    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true); // 게임 오버 화면 활성화
    }


}
