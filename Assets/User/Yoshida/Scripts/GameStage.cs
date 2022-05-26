using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    public GameObject bgPrefab;
    public GameObject blockPrefab;
    public GameObject charactorPrefab;
    public GameObject ItemPrefab;

    void Start()
    {
        int[][] tileMap = //二次元配列によるマップ情報
        {
            new int[] {1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 0, 0, 0, 3, 0, 0, 1},
            new int[] {1, 0, 2, 0, 0, 0, 1, 1},
            new int[] {1, 0, 0, 0, 0, 0, 0, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1}
        };

        //For文の二重ループによるインスタンスの生成
        for (int i = 0; i < tileMap.Length; i++)
        {
            for (int j = 0; j < tileMap[i].Length; j++)
            {

                if (tileMap[i][j] == 0)
                {
                    //背景を生成
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 1)
                {
                    //壁を生成
                    Instantiate(blockPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 2)
                {
                    //キャラクターを生成
                    Instantiate(charactorPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                    //キャラクターと重なる部分の背景を生成
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
                if (tileMap[i][j] == 3)
                {
                    //アイテムを生成
                    Instantiate(ItemPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                    //キャラクターと重なる部分の背景を生成
                    Instantiate(bgPrefab, new Vector3(j, tileMap.Length - i, 0), Quaternion.identity);
                }
            }
        }
    }
}
