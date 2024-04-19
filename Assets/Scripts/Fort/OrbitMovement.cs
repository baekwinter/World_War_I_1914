using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform centerObject; // �߽� ������Ʈ (�÷��̾�)
    public float radius = 2.26f; // ���� ������
    public float speed = 1.0f; // ȸ�� �ӵ�

    private float angle = 0; // ���� ����

    private void Start()
    {
        // ���� ���� �ÿ� �߽� ������Ʈ ����
        if (GameManager.Instance.Fort != null)
        {
            centerObject = GameManager.Instance.Fort.transform;
        }
    }

    private void Update()
    {
        if (centerObject == null)
        {
            // �߽� ������Ʈ�� ������ ������Ʈ ����
            return;
        }

        // ������ �ð��� ���� ������Ű��
        angle += speed * Time.deltaTime; // ���ӵ� ����

        // ��ġ ���
        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.y + Mathf.Sin(angle) * radius;

        // ������Ʈ ��ġ ������Ʈ
        transform.position = new Vector3(x, y, centerObject.position.z);
    }
}
