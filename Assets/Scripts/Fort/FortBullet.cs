using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//요새가 몬스터에게 쏘는 총알의 데미지처리 
public class FortBullet : MonoBehaviour
{
    [SerializeField] private int _bulletId;
    public BulletData _bulletData;
    private Rigidbody2D _bulletRigidbody;


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
           
           enemy.TakeDamage(_bulletData.BulletAtk);
            //총알이 요새에 맞았을때 로그로 출력
            Debug.Log(gameObject.name + "총알이 적에게 맞았습니다.");
            Destroy(gameObject);
        }
    }

}
