using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    //범위, 레이어, 스캔 결과 배열, 가장 가까운 목표를 담을 변수 선언
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    //원형의 캐스트를 쏘고 모든 결과를 반환하기 
    private void FixedUpdate()
    {
        //캐스팅 시작위치, 원의 반지름, 캐스팅 방향, 캐스팅 길이, 대상레이어
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
    }

    //가장 가까운 것 찾는 함수
    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100; // 거리계산

        foreach(RaycastHit2D target in targets)// CircleCastAll에 맞은 애들
        {
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDiff = Vector2.Distance(myPos, targetPos); //myPos와 targetPos의 거리를 계산해주는 함수

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
            return result;
    }

}
