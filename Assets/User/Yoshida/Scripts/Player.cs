using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;   //(操作)移動したいオブジェクトを設定
    Vector3 movePosition;　//移動する距離を格納
    public int speed = 5;　//1マス毎に移動するスピード

    //今自分がいる配列上の位置を保管
    static private Vector2 nowPlayerPosition = Vector2.zero;

    public static void SetPlayerPos(int x, int y)
    {
        nowPlayerPosition = new Vector2(x, y);
        Debug.Log($"nowPlayerPosition x:{nowPlayerPosition.x} y;{nowPlayerPosition.y}");
    }

    void Start()
    {
    }

    void Update()
    {
        //移動場所設定
        //キー入力を行うと、moveButtonJudge = true に変わり、一時的にキー入力を無効
        if (Input.GetKeyDown(KeyCode.W))
        {
            var targetPos = new Vector2(player.transform.position.x, player.transform.position.y + 1);
            var targetArrayIndex = new Vector2(nowPlayerPosition.x, nowPlayerPosition.y - 1);
            if (GameStage.CheckCollision((int)targetArrayIndex.x, (int)targetArrayIndex.y) == false)
            {
                player.transform.position = targetPos;
                nowPlayerPosition = targetArrayIndex;
                Debug.Log($"nowPlayerPosition x:{nowPlayerPosition.x} y;{nowPlayerPosition.y}");
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {


            var targetPos = new Vector2(player.transform.position.x, player.transform.position.y - 1);
            var targetArrayIndex = new Vector2(nowPlayerPosition.x, nowPlayerPosition.y + 1);
            if (GameStage.CheckCollision((int)targetArrayIndex.x, (int)targetArrayIndex.y) == false)
            {
                player.transform.position = targetPos;
                nowPlayerPosition = targetArrayIndex;
                Debug.Log($"nowPlayerPosition x:{nowPlayerPosition.x} y;{nowPlayerPosition.y}");
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            var targetPos = new Vector2(player.transform.position.x + 1, player.transform.position.y);
            var targetArrayIndex = new Vector2(nowPlayerPosition.x + 1, nowPlayerPosition.y);
            if (GameStage.CheckCollision((int)targetArrayIndex.x, (int)targetArrayIndex.y) == false)
            {
                player.transform.position = targetPos;
                nowPlayerPosition = targetArrayIndex;
                Debug.Log($"nowPlayerPosition x:{nowPlayerPosition.x} y;{nowPlayerPosition.y}");
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            var targetPos = new Vector2(player.transform.position.x - 1, player.transform.position.y);
            var targetArrayIndex = new Vector2(nowPlayerPosition.x - 1, nowPlayerPosition.y);
            if (GameStage.CheckCollision((int)targetArrayIndex.x, (int)targetArrayIndex.y) == false)
            {
                player.transform.position = targetPos;
                nowPlayerPosition = targetArrayIndex;
                Debug.Log($"nowPlayerPosition x:{nowPlayerPosition.x} y;{nowPlayerPosition.y}");
            }
        }

    }
}
