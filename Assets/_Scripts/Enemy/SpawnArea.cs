using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public BoxCollider2D innerRing;
    public BoxCollider2D outerRing;


    // 获取小碰撞器的边界
    private Bounds smallBounds;

    // 获取大碰撞器的边界
    private Bounds largeBounds;


    void Start()
    {
        //Intersects(Bounds bounds): 这个方法用于检测两个包围体积是否相交，返回一个布尔值。如果两个包围体积有重叠或边界接触，它们被视为相交。

        //Contains(Vector3 point): 这个方法用于检测一个点是否位于包围体积内，返回一个布尔值。

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
