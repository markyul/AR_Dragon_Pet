using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsTrack : MonoBehaviour
{
    public Color lineColor = Color.yellow;
    private Transform[] points;

    void OnDrawGizmos()
    {
        // 라인 색 지정
        Gizmos.color = lineColor;
        points = GetComponentsInChildren<Transform>();

        int nextIndex = 1;

        Vector3 currentPosition = points[nextIndex].position;
        Vector3 nextPosition;

        // Point 게임 오브젝트를 순회하면서 라인그리기
        for(int i = 0; i <= points.Length; i++)
        {
            nextPosition = (++nextIndex >= points.Length) ? points[1].position : points[nextIndex].position;
            Gizmos.DrawLine(currentPosition, nextPosition);

            currentPosition = nextPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
