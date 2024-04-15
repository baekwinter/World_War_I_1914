using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PoolManager pool;
    public Transform Fort;
    private void Awake()
    {
        Instance = this; 
    }

}
