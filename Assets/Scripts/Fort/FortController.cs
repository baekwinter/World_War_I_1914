using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortController : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
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

    // 요새 방향 로직
    void Update()
    {
        if (dynamicJoystick != null)
        {
            Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
            // 조이스틱을 움직일때만 요새를 회전시키도록 조건을 추가합니다.
            if (direction.magnitude > 0.1f)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
            else
            {
                // 조이스틱을 움직이지 않을 때 회전을 멈추거나 초기화를 원하면 여기에 코드를 추가합니다.
                // 예를 들어, 요새를 기본 방향(예: 0도)으로 회전시키려면 아래와 같이 작성합니다.
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
        else
        {
            Debug.LogWarning("Joystick 객체가 할당되지 않았습니다.");
        }
    }

    // 이동 로직
    public void FixedUpdate()
    {
        Vector2 direction = new Vector2(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
        rb.velocity = direction.normalized * _fortSpeed;
    }
}
