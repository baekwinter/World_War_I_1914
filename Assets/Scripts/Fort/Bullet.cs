using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //데미지와 관통변수 선언
    public float damage;
    public int per;

    public void Init(float damage, int per)
    {
        //해당 클래스의 변수로 접근
        this.damage = damage;
        this.per = per;
    }
}
