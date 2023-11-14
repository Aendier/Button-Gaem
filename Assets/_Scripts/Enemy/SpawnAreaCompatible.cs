using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SpawnAreaCompatible : MonoBehaviour
{
    public SpawnArea spawnArea;
    public float distance = 50f;

    private void OnValidate()
    {
        spawnArea = GetComponentInChildren<SpawnArea>();
    }

    private void Awake()
    {
        spawnArea = GetComponentInChildren<SpawnArea>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update-SpawnAreaCompatible");


        // 获取摄像机的正交大小和视野宽高比
        float orthographicSize = Camera.main.orthographicSize;
        float aspectRatio = Camera.main.aspect;

        // 获取屏幕高度
        float screenHeight = 2 * orthographicSize;

        // 计算屏幕宽度
        float screenWidth = screenHeight * aspectRatio;
        spawnArea.innerRing.size = new Vector2 (screenWidth, screenHeight);
        spawnArea.outerRing.size = new Vector2(screenWidth + distance, screenHeight + distance);
        // 输出结果
        Debug.Log("屏幕宽度在世界坐标中的长度: " + screenWidth);
        Debug.Log("屏幕高度在世界坐标中的长度: " + screenHeight);
    }
}
