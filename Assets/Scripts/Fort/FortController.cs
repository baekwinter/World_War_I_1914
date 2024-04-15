using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortController : MonoBehaviour
{
   
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb ;
    [SerializeField] private Fort _fort;
    [SerializeField] private float _fortSpeed;
    private void Awake()
    {
        _fort = GetComponent<Fort>();
        
    }
    private void Start()
    {
        _fortSpeed = _fort._fortState.Fort_Speed;
    }
    //��� ���� ����
    void Update()
    {
        if (dynamicJoystick != null)
        {
            Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
            if (direction.magnitude > 0.1f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        else
        {
            Debug.LogWarning("Joystick ��ü�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
    //�̵�����
    public void FixedUpdate()
    {
        Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
        rb.velocity = direction.normalized * _fortSpeed;
    }

}
