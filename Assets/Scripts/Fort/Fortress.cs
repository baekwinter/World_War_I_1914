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
        // �ֺ� �� Ž��
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // �����Ÿ� ���� �ִ� �� ����
            if (Vector3.Distance(transform.position, enemy.transform.position) <= _fortState.Fort_AtkRange)
            {
                // źȯ ���� �� �߻�
                GameObject bullet = Instantiate(autoBulletPrefab, transform.position, transform.rotation);
                FortBullet bulletScript = bullet.GetComponent<FortBullet>();

                // �Ѿ� �߻� ���� ����
                Vector3 direction = (enemy.transform.position - transform.position).normalized;
                bullet.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletScript._bulletData.BulletSpeed;
            }
        }
    }




}
