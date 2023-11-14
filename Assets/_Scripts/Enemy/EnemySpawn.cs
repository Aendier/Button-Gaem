using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EnemySpawn : MonoBehaviour
{
    public bool isSpawn;
    public GameObject enemy;

    private void Awake()
    {
        enemy = Addressables.LoadAssetAsync<GameObject>("Enemy").WaitForCompletion();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector2 screenTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
            Vector2 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Vector2 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            Vector2 screenBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
            Vector2 spawnPosition;
            switch (Random.Range(0, 4))
            {
                case 0:// ��������Ұ�Ϸ�֮��
                    spawnPosition = new Vector2(Random.Range(screenTopLeft.x, screenTopRight.x), screenTopRight.y + 10f);
                    break;
                case 1:// ��������Ұ�·�֮��
                    spawnPosition = new Vector2(Random.Range(screenBottomLeft.x, screenBottomRight.x), screenBottomRight.y - 1.0f);
                    break;
                case 2:// ��������Ұ��֮��
                    spawnPosition = new Vector2(screenTopRight.x - 1.0f, Random.Range(screenTopLeft.y, screenBottomLeft.y));
                    break;
                case 3:// ��������Ұ�ҷ�֮��
                    spawnPosition = new Vector2(screenTopRight.x + 1.0f, Random.Range(screenTopRight.y, screenBottomRight.y));
                    break;
                default:// Ĭ��
                    spawnPosition = new Vector2(Random.Range(screenTopLeft.x, screenTopRight.x), screenTopRight.y + 1.0f);
                    break;
            }


            // ʵ��������
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
