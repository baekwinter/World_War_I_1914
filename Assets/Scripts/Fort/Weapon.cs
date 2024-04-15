using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int _weponId; // 무기 ID
    public int _prefabId; //무기 프리펩 ID
    public float _weaponDamage; //데미지
    public int _weaponCount; //개수
    public float weaponSpeed; // 회전 속도

    private void Start()
    {
        Init();
    }
   

    // ID에 따라 다르게 할것
    public void Init()
    {
        switch(_weponId)
        {
            case 0:
                weaponSpeed = -10;
                //Batch();
                break;
            default:
                break;
        }
    }
    //생성된 무기를 배치하는 함수 생성 및 호출
    //void Batch()
    //{
    //    for (int index = 0; index < _weaponCount; index++)
    //    {
    //        //가져온 오브젝트의 TransForm을 지역변수로 저장해두기
    //        Transform bullet = Get(_prefabId).transform;
    //        //부모를 변경
    //        bullet.parent = transform;
    //        // -1 is Infinity per ==  -1은 무한으로 관통
    //        bullet.GetComponent<Bullet>().Init(_weaponDamage, -1);
    //    }
    //}
}
