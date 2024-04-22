using UnityEngine;

[System.Serializable]
public class BulletData
{
    [SerializeField] private int _id;
    [SerializeField] private string _bulletEngName; // ��ź�����̸�
    [SerializeField] private string _bulletKoreaName; //��ź�ѱ��̸�
    [SerializeField] private float _bulletAtk; //����
    [SerializeField] private float _bulletSpeed; //�ӵ�
    [SerializeField] private float _bulletAtkRange; // �����Ÿ�
    [SerializeField] private string _bulletPrefabPath; //�������ּ�

    public int Id => _id;
    public string BulletEngName => _bulletEngName;
    public string BulletKoreaName => _bulletKoreaName;
    public float BulletAtk => _bulletAtk;
    public float BulletSpeed => _bulletSpeed;
    public float BulletAtkRange => _bulletAtkRange;
    public string BulletPrefabPath => _bulletPrefabPath;
}
