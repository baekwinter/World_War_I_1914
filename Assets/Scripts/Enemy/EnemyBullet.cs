using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //데미지와 관통변수 선언
    public float damage;
    public int per;
    public void Init(float damage_)
    {
        //해당 클래스의 변수로 접근
        damage = damage_;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fort fort = collision.gameObject.GetComponent<Fort>();
        if (fort != null && collision.CompareTag("Fort"))
        {
            fort.TakeDamage(damage);
            //총알이 요새에 맞았을때 로그로 출력
            Debug.Log(gameObject.name + "총알이" + fort._fortState.Fort_Name + " 요새에 맞았습니다.");
            Destroy(gameObject);
        }
        // 총알이 요새에 맞은 후 사라지게 합니다.
       
    }
}
    
