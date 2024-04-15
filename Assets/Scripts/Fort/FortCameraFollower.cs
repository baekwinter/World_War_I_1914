using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform fortTransform; // 요새의 Transform 컴포넌트
    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    private void Start()
    {
        fortTransform = GameManager.Instance.Fort.transform;
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = fortTransform.position; // 요새의 위치를 가져옴
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 부드러운 이동을 위해 Lerp 사용
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // 카메라 위치 업데이트
    }
}
