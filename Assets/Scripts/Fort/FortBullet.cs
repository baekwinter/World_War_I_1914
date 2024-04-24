using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� ���Ϳ��� ��� �Ѿ��� ������ó�� 
public class FortBullet : MonoBehaviour
{
    [SerializeField] private int _bulletId;
    [SerializeField] public BulletData _bulletData;
     private Rigidbody2D _bulletRigidbody;
    [SerializeField] public FortState _fortState;

    private void Awake()
    {
        _bulletData = DataBase.Bullet.Get(_bulletId);
        _bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null && collision.CompareTag("Enemy"))
        {
           
           enemy.EnemyTakeDamage(_fortState.Fort_Atk +_bulletData.BulletAtk);
            //�Ѿ��� ����� �¾����� �α׷� ���
            Debug.Log(gameObject.name + "�Ѿ��� ������ �¾ҽ��ϴ�.");
            Destroy(gameObject);
        }
    }

}
