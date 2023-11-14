using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public BoxCollider2D innerRing;
    public BoxCollider2D outerRing;


    // ��ȡС��ײ���ı߽�
    private Bounds smallBounds;

    // ��ȡ����ײ���ı߽�
    private Bounds largeBounds;


    void Start()
    {
        //Intersects(Bounds bounds): ����������ڼ��������Χ����Ƿ��ཻ������һ������ֵ�����������Χ������ص���߽�Ӵ������Ǳ���Ϊ�ཻ��

        //Contains(Vector3 point): ����������ڼ��һ�����Ƿ�λ�ڰ�Χ����ڣ�����һ������ֵ��

    }

    public Vector2 SpawnPoint()
    {
        smallBounds = innerRing.bounds;
        largeBounds = outerRing.bounds;
        Vector2 point = new(Random.Range(largeBounds.min.x, largeBounds.max.x), Random.Range(largeBounds.min.y, largeBounds.max.y));
        Debug.Log(point);
        if (largeBounds.Contains(point) && !smallBounds.Contains(point)) return point;
        else return new(Random.Range(largeBounds.min.x, largeBounds.max.x), Random.Range(largeBounds.min.y, largeBounds.max.y));
    }
}
