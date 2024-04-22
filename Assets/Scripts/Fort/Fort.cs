using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FortState 
{
    [SerializeField] private string _fort_Name;
    [SerializeField] private float _fort_Hp;
    [SerializeField] private float _fort_Atk;
    [SerializeField] private float _fort_Def;
    [SerializeField] private float _fort_Speed;
    [SerializeField] private float _fort_AtkRange;

    //프로퍼티
    public string Fort_Name { get { return _fort_Name; } set { _fort_Name = value; } }
    public float Fort_Hp { get { return _fort_Hp; } set { _fort_Hp = value; } }
    public float Fort_Atk { get { return _fort_Atk; } set { _fort_Atk = value; } }
    public float Fort_Def { get { return _fort_Def; } set { _fort_Def = value; } }
    public float Fort_Speed { get { return _fort_Speed; } set { _fort_Speed = value; } }
    public float Fort_AtkRange { get { return _fort_AtkRange; } set { _fort_AtkRange = value; } }

}

public class Fort : MonoBehaviour
{
    [SerializeField] public FortState _fortState;
    [SerializeField] private int _fortId;
    private float _lastAttackTime = 0f;

    private void Awake()
    {
        _fortState.Fort_Name = DataBase.Fort.Get(_fortId).FortName;
        _fortState.Fort_Hp = DataBase.Fort.Get(_fortId).FortHp;
        _fortState.Fort_Atk = DataBase.Fort.Get(_fortId).FortAtk;
        _fortState.Fort_Def = DataBase.Fort.Get(_fortId).FortDef;
        _fortState.Fort_AtkRange = DataBase.Fort.Get(_fortId).FortAtkRange;
        _fortState.Fort_Speed = DataBase.Fort.Get(_fortId).FortSpeed;
    }

    private void Update()
    {
        AttackEnemies();
    }

    private void AttackEnemies()
    {
        // 공격 쿨다운 체크
        if (Time.time - _lastAttackTime >= 1f / _fortState.Fort_Speed)
        {
            // 공격 범위 내 적 찾기
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _fortState.Fort_AtkRange);
            foreach (Collider2D collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    // 적에게 데미지 주기
                    float damage = _fortState.Fort_Atk - enemy.Defense;
                    if (damage > 0)
                    {
                        enemy.TakeDamage(Mathf.RoundToInt(damage));
                        Debug.Log($"{_fortState.Fort_Name} 요새가 {enemy.gameObject.name} 적을 공격했습니다. 데미지: {damage}");
                    }
                    _lastAttackTime = Time.time;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        
        _fortState.Fort_Hp -= damage;
        GameManager.Instance.CallOnDamageEvent();
        Debug.Log(damage); // 데미지가 들어가는지 체크하기
        
        if (_fortState.Fort_Hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 요새가 파괴되었을 때의 처리를 구현
        Debug.Log(_fortState.Fort_Name + " 요새가 파괴되었습니다.");
        // 요새 파괴 후 필요한 처리를 추가
        FindObjectOfType<GameManager>().ShowGameOver(); // 게임 오버 화면 표시
    }
}

