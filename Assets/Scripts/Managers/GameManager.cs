using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public Transform Player;
    private void Awake()
    {
        Instance = this; 
    }

}
