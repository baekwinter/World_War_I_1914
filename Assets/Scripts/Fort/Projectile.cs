using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetPosition;

    public void Launch(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    void Update()
    {
        if (targetPosition != null)
        {
            // ������Ÿ���� ��� ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // ��� �����ϸ� ������Ÿ�� �ı�
            if (transform.position == targetPosition)
            {
                Destroy(gameObject);
            }
        }
    }
}
