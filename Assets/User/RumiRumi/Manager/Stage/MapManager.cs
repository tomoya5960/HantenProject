using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region　ステージで必須な物
    [Header("ステージナンバー")]
    public int selectStageNum = 0;  //ステージ番号を格納
    [Header("反転可能数")]
    public int stageTurnCount = 0;  //反転できる残りの回数
    [HideInInspector]
    public Vector2 PlayerPos = Vector2.zero;
    [HideInInspector]
    public Vector2 GoalPos = Vector2.zero;
    private LoadOnlyJson _loadJson;      //_loadOnlyJson取得するために使うやーつ
    #endregion

    #region MAPに必要な物

    #region マップの二次元配列
    public MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    #region アイテムの二次元配列
    public ItemPosition[] itemPosX = new ItemPosition[7];
    [System.Serializable]
    public class ItemPosition
    {
        public GameObject[] itemPosY = new GameObject[8];
    }
    #endregion

    #endregion

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    public bool Move(int vecTest)
    {
        var isMove = false;
        switch(vecTest)
        {
            case 0: //上
                if (mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove =  true;
                break;
            case 1: //下
                if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 2: //左
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
            case 3: //右
                if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableStone)
                    isMove = false;
                else if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                    isMove = true;
                break;
        }
        return isMove;
    }

    /// <summary>
    /// プレイヤーの下が氷床かどうかチェックする関数
    /// </summary>
    public bool IsIceFloor(int direction)
    {
        var isMove = false;
        if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().imageID == (int)MapType.ImageIdType.aisle_03)
        {
            switch (direction)
            {
                case 0://上
                    if(mapPosX[(int)PlayerPos.x - 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
                case 1://下
                    if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
                case 2://左
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
                case 3://右
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                        isMove = true;
                    break;
            }
        }
        return isMove;
    }

    /// <summary>
    /// プレイヤーの移動後に自分とおなじ場所のタイルに何らかの物が落ちているか
    /// </summary>
    public bool isUnderRope()
    {
        if (itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject != null)
        {
            if (itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.tag == "Rope")
            {
                itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.SetActive(false);
                Debug.Log($"<color=green>ロープを取りました</color>");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// クリアしたか判定するよ。
    /// </summary>
    public void IsCheckClear()
    {
        if (PlayerPos == GoalPos)
        {
            Debug.Log("ゴールしたよ");
        }
    }


    /// <summary>
    /// そのステージでの反転を使用した際に使う関数
    /// </summary>
    public void StageTurnNum()
    {
        if (stageTurnCount != 0) //反転回数が残っていたら残りの使用回数を減らす
        {
            stageTurnCount--;
            Debug.Log("反転しました。");
        }
        else
            Debug.Log("反転できません");
    }

    /// <summary>
    /// tileDataListのオブジェクトを二次元配列に再整列する関数
    /// </summary>
    public void SetTileArray()
    {
        if (GameObject.Find("LoadData"))
            _loadJson = GameObject.Find("LoadData").GetComponent<LoadOnlyJson>();

        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = _loadJson.tileDataList[TileNum];
                mapPosX[i].mapPosY[j].GetComponent<TileData>().tilePos = new Vector2(i, j);
                TileNum++;
            }
        }
    }
}
