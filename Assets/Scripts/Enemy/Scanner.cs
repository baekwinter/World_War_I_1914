using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    //����, ���̾�, ��ĵ ��� �迭, ���� ����� ��ǥ�� ���� ���� ����
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    //������ ĳ��Ʈ�� ��� ��� ����� ��ȯ�ϱ� 
    private void FixedUpdate()
    {
        //ĳ���� ������ġ, ���� ������, ĳ���� ����, ĳ���� ����, ����̾�
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    //���� ����� �� ã�� �Լ�
    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100; // �Ÿ����

        foreach(RaycastHit2D target in targets)// CircleCastAll�� ���� �ֵ�
        {
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDiff = Vector2.Distance(myPos, targetPos); //myPos�� targetPos�� �Ÿ��� ������ִ� �Լ�

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
            return result;
    }

}
