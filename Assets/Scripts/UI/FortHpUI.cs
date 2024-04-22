using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortHpUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private FortState _fortState;
    [SerializeField] private float _fortMaxHp;
    private void Awake()
    {
        _fortState = GameManager.Instance.Fort.GetComponent<Fort>()._fortState;
        GameManager.Instance.OnDamageEvent += UpdateFortHpUI;
    }
    private void Start()
    {
        _fortMaxHp = _fortState.Fort_Hp;
    }
    private void UpdateFortHpUI()
    {
        _hpSlider.value = _fortState.Fort_Hp / _fortMaxHp;
    }
}
