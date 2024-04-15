using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform centerObject; // 중심 오브젝트 (플레이어)
    public float radius = 2.26f; // 원의 반지름
    public float speed = 1.0f; // 회전 속도

    private float angle = 0; // 시작 각도
    
    
    private void Update()
    {
        centerObject = GameManager.Instance.Fort.transform;
        // 각도를 시간에 따라 증가시키기
        angle += speed * Time.deltaTime; // 각속도 조절

        // 위치 계산
        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;

        // 오브젝트 위치 업데이트
        transform.position = new Vector3(x, y, centerObject.position.z);
    }
}