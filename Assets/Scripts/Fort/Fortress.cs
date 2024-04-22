using UnityEngine;
using System.Collections;
public class Fortress : MonoBehaviour
{

    [SerializeField] private GameObject autoBulletPrefab;
    [SerializeField] private Fort _fort;
    private FortState _fortState;

    private void Awake()
    {
        _fort = GetComponent<Fort>();
        _fortState = _fort._fortState;
    }

    private void Start()
    {
        StartCoroutine(AutoAttack());
    }


    IEnumerator AutoAttack()
    {
        while (true)
        {
            AttackEnemy();
            yield return new WaitForSeconds(1 );
        }
    }

    void AttackEnemy()
    {
        // 주변 적 탐색
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // 사정거리 내에 있는 적 공격
            if (Vector3.Distance(transform.position, enemy.transform.position) <= _fortState.Fort_AtkRange)
            {
                // 탄환 생성 및 발사
                GameObject bullet = Instantiate(autoBulletPrefab, transform.position, transform.rotation);
                FortBullet bulletScript = bullet.GetComponent<FortBullet>();

                // 총알 발사 방향 설정
                Vector3 direction = (enemy.transform.position - transform.position).normalized;
                bullet.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletScript._bulletData.BulletSpeed;
            }
        }
    }




}
