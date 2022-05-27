using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    public GameObject bgPrefab;
    public GameObject blockPrefab;
    public GameObject charactorPrefab;
    public GameObject ItemPrefab;

    private static int[][] tileMap =
        {
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 0, 0, 3, 0, 0, 1 },
            new int[] { 1, 0, 2, 0, 0, 0, 1, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }
        };
    public static int[][] TileMap => tileMap;

    public static bool CheckCollision(int x, int y)
    {
        Debug.Log($"Collision Check {x}, {y}");
        if (x < 0) return true;
        if (y < 0) return true;
        if (x > tileMap[0].Length - 1) return true;
        if (y > tileMap.Length - 1) return true;

        if (tileMap[y][x] == 1) return true;

        return false;
    }


    void Start()
    {
        //FIXME　TODO　Editor拡張で作ったゲームステージを、ここで
        //tileMapにいれてあげる

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
                    //自分の発生位置をPlayerに教える
                    Player.SetPlayerPos(j, i);
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
