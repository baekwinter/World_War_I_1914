using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int _weponId; // ���� ID
    public int _prefabId; //���� ������ ID
    public float _weaponDamage; //������
    public int _weaponCount; //����
    public float weaponSpeed; // ȸ�� �ӵ�

    private void Start()
    {
        Init();
    }
   

    // ID�� ���� �ٸ��� �Ұ�
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
    //������ ���⸦ ��ġ�ϴ� �Լ� ���� �� ȣ��
    //void Batch()
    //{
    //    for (int index = 0; index < _weaponCount; index++)
    //    {
    //        //������ ������Ʈ�� TransForm�� ���������� �����صα�
    //        Transform bullet = Get(_prefabId).transform;
    //        //�θ� ����
    //        bullet.parent = transform;
    //        // -1 is Infinity per ==  -1�� �������� ����
    //        bullet.GetComponent<Bullet>().Init(_weaponDamage, -1);
    //    }
    //}
}
