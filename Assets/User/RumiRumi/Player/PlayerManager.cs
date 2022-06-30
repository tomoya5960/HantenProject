using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Canvas canvas;
    [HideInInspector]
    public bool isHaveRope = false;    //ロープを持っているか
    [HideInInspector]
    public Vector2 isPlayerPos = Vector2.zero;
    public float playerSpeed = 2;
    public bool isPlayerMove = false;  //プレイヤーが動いているか

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
            isPlayerPos = GeneralManager.instance.mapManager.PlayerPos;    //プレイヤーのスタート位置を格納
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
                    isPlayerPos += new Vector2(-1, 0);
                    gameObject.transform.Translate(0, 130, 0);
                }
                else
                    CheckGoal(0);
                break;
            case 1:
                if (GeneralManager.instance.mapManager.Move(1))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(1, 0);
                    isPlayerPos += new Vector2(1, 0);
                    gameObject.transform.Translate(0, -130, 0);
                }
                else
                    CheckGoal(1);
                break;
            case 2:
                if (GeneralManager.instance.mapManager.Move(2))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, -1);
                    isPlayerPos += new Vector2(0, -1);
                    gameObject.transform.Translate(-130, 0, 0);
                }
                else
                    CheckGoal(2);
                break;
            case 3:
                if (GeneralManager.instance.mapManager.Move(3))
                {
                    GeneralManager.instance.mapManager.PlayerPos += new Vector2(0, 1);
                    isPlayerPos += new Vector2(0, 1);
                    gameObject.transform.Translate(130, 0, 0);
                }
                else
                    CheckGoal(3);
                break;
            default:
                Debug.Log("移動可能か検索するところで変な指示出してんじゃねえよ");
                break;
        }
        GeneralManager.instance.mapManager.IsCheckClear();
    }

    /// <summary>
    /// 移動先がゴールで、ロープを持っていたらゴールできるようにする
    /// </summary>
    /// <param name="direction"></param>
    public void CheckGoal(int direction)
    {
        GameObject obj;
        switch (direction)
        {
            case 0:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x - 1].mapPosY[(int)isPlayerPos.y].gameObject;
                break;
            case 1:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x + 1].mapPosY[(int)isPlayerPos.y].gameObject;
                break;
            case 2:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x].mapPosY[(int)isPlayerPos.y - 1].gameObject;
                break;
            case 3:
                obj = GeneralManager.instance.mapManager.mapPosX[(int)isPlayerPos.x].mapPosY[(int)isPlayerPos.y + 1].gameObject;
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
}