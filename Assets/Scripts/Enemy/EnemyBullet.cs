using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fort fort = collision.gameObject.GetComponent<Fort>();
        if (fort != null && collision.CompareTag("Fort"))
        {
            // �Ѿ��� �������� �����մϴ�.
            int damage = 10;
            fort.TakeDamage(damage);
            //�Ѿ��� ����� �¾����� �α׷� ���
            Debug.Log(gameObject.name + "�Ѿ���" + fort._fortState.Fort_Name + " ����� �¾ҽ��ϴ�.");
            Destroy(gameObject);
        }
        // �Ѿ��� ����� ���� �� ������� �մϴ�.
       
    }
}
    
