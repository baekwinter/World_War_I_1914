using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�������� ���뺯�� ����
    public float damage;
    public int per;

    public void Init(float damage, int per)
    {
        //�ش� Ŭ������ ������ ����
        this.damage = damage;
        this.per = per;
    }
}
