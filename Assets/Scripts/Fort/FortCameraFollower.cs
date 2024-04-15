using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform fortTransform; // ����� Transform ������Ʈ
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    private void Start()
    {
        fortTransform = GameManager.Instance.Fort.transform;
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = fortTransform.position; // ����� ��ġ�� ������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // �ε巯�� �̵��� ���� Lerp ���
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // ī�޶� ��ġ ������Ʈ
    }
}
