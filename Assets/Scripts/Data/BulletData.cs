using UnityEngine;

[System.Serializable]
public class BulletData
{
    [SerializeField] private int _id;
    [SerializeField] private string _bulletEngName; // ÃÑÅº¿µ¾îÀÌ¸§
    [SerializeField] private string _bulletKoreaName; //ÃÑÅºÇÑ±ÛÀÌ¸§
    [SerializeField] private float _bulletAtk; //°ø°Ý
    [SerializeField] private float _bulletSpeed; //¼Óµµ
    [SerializeField] private float _bulletAtkRange; // »çÁ¤°Å¸®
    [SerializeField] private string _bulletPrefabPath; //ÇÁ¸®ÆÕÁÖ¼Ò

    public int Id => _id;
    public string BulletEngName => _bulletEngName;
    public string BulletKoreaName => _bulletKoreaName;
    public float BulletAtk => _bulletAtk;
    public float BulletSpeed => _bulletSpeed;
    public float BulletAtkRange => _bulletAtkRange;
    public string BulletPrefabPath => _bulletPrefabPath;
}
