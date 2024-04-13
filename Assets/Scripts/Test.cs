using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DataBase.Enemy.Get(10000000).EnemyName);
        Debug.Log(DataBase.Fort.Get(10000100).FortName);
        Debug.Log(DataBase.Stage.Get(11).StageName);
        Debug.Log(DataBase.EnemyGroup.Get(1001).EnemyGroupName);
        Debug.Log(DataBase.Commander.Get(10001100).CommanderName);


    }


}
