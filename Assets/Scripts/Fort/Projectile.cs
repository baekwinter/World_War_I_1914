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
            // 프로젝타일을 대상 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // 대상에 도달하면 프로젝타일 파괴
            if (transform.position == targetPosition)
            {
                Destroy(gameObject);
            }
        }
    }
}
