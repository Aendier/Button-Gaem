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


        // ��ȡ�������������С����Ұ��߱�
        float orthographicSize = Camera.main.orthographicSize;
        float aspectRatio = Camera.main.aspect;

        // ��ȡ��Ļ�߶�
        float screenHeight = 2 * orthographicSize;

        // ������Ļ���
        float screenWidth = screenHeight * aspectRatio;
        spawnArea.innerRing.size = new Vector2 (screenWidth, screenHeight);
        spawnArea.outerRing.size = new Vector2(screenWidth + distance, screenHeight + distance);
        // ������
        Debug.Log("��Ļ��������������еĳ���: " + screenWidth);
        Debug.Log("��Ļ�߶������������еĳ���: " + screenHeight);
    }
}
