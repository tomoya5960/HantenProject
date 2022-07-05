using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Canvas canvas;
    //[HideInInspector]
    public bool isHaveRope = false;    //ロープを持っているか
    [HideInInspector]
    public Vector2 playerPos = Vector2.zero;
    public Vector2 nowPos;
    [SerializeField]
    private float _playerSpeed = 2;
    public bool isPlayerMove = false;  //プレイヤーが動いているか
    private int _playerdis = 130;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").gameObject.GetComponent<Canvas>();
    }
    void Start()
    {

        //マップツールで生成されたプレイヤーを動かないようにする
        if (SceneManager.GetActiveScene().name == "MapEditorScene")
        {
            //マップツールで読み込みを行った際にBeforePlayerに読み込まれたマップにあるPlayerを格納する。これをすることで読み込みを行った際のPlayerが重複することを防ぐ
            GameObject.Find("MapTool").gameObject.GetComponent<Mouse>().beforePlayer = gameObject.transform.parent.gameObject;
            gameObject.GetComponent<Player>().enabled = false;
            gameObject.GetComponent<PlayerManager>().enabled = false;
        }
        else
        {
            GeneralManager.instance.mapManager.PlayerPos = gameObject.transform.parent.GetComponent<TileData>().tilePos;
            playerPos = GeneralManager.instance.mapManager.PlayerPos;    //プレイヤーのスタート位置を格納
            GeneralManager.instance.mapManager.SetBeforeStageData();
            GameObject.Find("testButton").GetComponent<BeforeBack>().manager = GetComponent<PlayerManager>();
        }
    }

    /// <summary>
    /// Playerの座標情報の書き換え
    /// </summary>
    /// <param name="direction"></param>
    public void SetPlayerPos(int direction)
    {
        switch (direction)
        {
            case 0:
                if (GeneralManager.instance.mapManager.Move(0))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(-1, 0);
                    playerPos += new Vector2(-1, 0);
                    nowPos += new Vector2Int(0, _playerdis);
                    StartCoroutine(PlayerMove(direction));
                }
                else
                    CheckGoalSetRope(0);
                break;
            case 1:
                if (GeneralManager.instance.mapManager.Move(1))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(1, 0);
                    playerPos += new Vector2(1, 0);
                    nowPos += new Vector2Int(0, -_playerdis);
                    StartCoroutine(PlayerMove(direction));
                }
                else
                    CheckGoalSetRope(1);
                break;
            case 2:
                if (GeneralManager.instance.mapManager.Move(2))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, -1);
                    playerPos += new Vector2(0, -1);
                    nowPos += new Vector2Int(-_playerdis, 0);
                    StartCoroutine(PlayerMove(direction));
                }
                else
                    CheckGoalSetRope(2);
                break;
            case 3:
                if (GeneralManager.instance.mapManager.Move(3))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, 1);
                    playerPos += new Vector2(0, 1);
                    nowPos += new Vector2Int(_playerdis, 0);
                    StartCoroutine(PlayerMove(direction));
                }
                else
                    CheckGoalSetRope(3);
                break;
            default:
                Debug.Log("移動可能か検索するところで変な指示出してんじゃねえよ");
                break;
        }
    }

    /// <summary>
    /// 移動先がゴールで、ロープを持っていたらゴールできるようにする
    /// </summary>
    /// <param name="direction"></param>
    public void CheckGoalSetRope(int direction)
    {
        GameObject obj;
        switch (direction)
        {
            case 0:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)playerPos.x - 1].mapPosY[(int)playerPos.y].gameObject;
                break;
            case 1:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)playerPos.x + 1].mapPosY[(int)playerPos.y].gameObject;
                break;
            case 2:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)playerPos.x].mapPosY[(int)playerPos.y - 1].gameObject;
                break;
            case 3:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)playerPos.x].mapPosY[(int)playerPos.y + 1].gameObject;
                break;
            default:
                Debug.Log("移動可能か検索するところで変な指示出してんじゃねえよ");
                return;
        }
        //ゴールだったら
        if (obj.GetComponent<TileData>().imageID == (int)MapType.ImageIdType.goal_01 && isHaveRope)
        {
            obj.GetComponent<TileMaster>().TurnImage(isHaveRope);
            isHaveRope = false;
        }
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    IEnumerator PlayerMove(int direction)
    {
        float moveDis = 0;
        Vector3 movePos = new Vector3();
        isPlayerMove = true;

        switch (direction)
        {
            case 0:
                movePos = new Vector3(0, _playerSpeed, 0);
                break;
            case 1:
                movePos = new Vector3(0, -_playerSpeed, 0);
                break;
            case 2:
                movePos = new Vector3(-_playerSpeed, 0, 0);
                break;
            case 3:
                movePos = new Vector3(_playerSpeed, 0, 0);
                break;
            default:
                Debug.Log("移動可能か検索するところで変な指示出してんじゃねえよ");
                break;
        }
        while (true)    //移動
        {
            transform.Translate(movePos);
            moveDis += _playerSpeed;
            if (moveDis >= _playerdis)
            {
                isPlayerMove = false;
                if (!isHaveRope)
                    isHaveRope = GeneralManager.instance.mapManager.isUnderRope();
                GeneralManager.instance.mapManager.IsCheckClear();
                break;
            }
            yield return null;
        }
        yield break;
    }
}