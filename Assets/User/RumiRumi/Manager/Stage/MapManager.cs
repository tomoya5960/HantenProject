using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region　ステージで必須な物
    [Header("ステージナンバー")]
    public int selectStageNum = 0;  //ステージ番号を格納
    [HideInInspector]
    public GameObject HantenUI;
    private int _stageTurnCount = 0;    //反転できる残りの回数
    [HideInInspector]
    public int stageTurnCount
    {
        get { return _stageTurnCount; }
        set
        {
            _stageTurnCount = value;
            if(HantenUI != null)
            HantenUI.GetComponent<HantensuuUI>().hantensuu = _stageTurnCount;
        }
    }
    
    [HideInInspector]
    public 　　Vector2          PlayerPos = Vector2.zero;
    [HideInInspector]
    public 　　Vector2          GoalPos = Vector2.zero;
    [HideInInspector]
    public 　  GameObject _jsonDatas;      //_loadOnlyJson取得するために使うやーつ
    [Header("経過したターン数")]
    public int                        TurnNum = 0; //経過したターン数
    public GameObject[,] test = new GameObject[7,8];
    #endregion

    #region MAPに必要な物

    #region マップの二次元配列
    [HideInInspector]
    public MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    #region アイテムの二次元配列
    [HideInInspector]
    public ItemPosition[] itemPosX = new ItemPosition[7];
    [System.Serializable]
    public class ItemPosition
    {
        public GameObject[] itemPosY = new GameObject[8];
    }
    #endregion

    #region セーブに関する物
    [HideInInspector]
    public List<Vector2> _playerVecList = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> _playerPosList = new List<Vector2>();
    [HideInInspector]
    public List<int> _playerRoteSpriteNumList = new List<int>();
    [HideInInspector]
    public List<bool> _isplayerRopeList = new List<bool>();
    [HideInInspector]
    public List<int> _stageTurnContList = new List<int>();
    [HideInInspector]
    public List<string> stageData = new List<string>();
    [HideInInspector]
    public PlayerManager player;
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
        player.GetComponent<PlayerManager>().characterAnimationControl.SetActionMode(true);
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
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    } 
                    break;
                case 1://下
                    if (mapPosX[(int)PlayerPos.x + 1].mapPosY[(int)PlayerPos.y].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
                    break;
                case 2://左
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y - 1].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
                    break;
                case 3://右
                    if (mapPosX[(int)PlayerPos.x].mapPosY[(int)PlayerPos.y + 1].GetComponent<TileData>().isEnableProceed)
                    {
                        GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_04);
                        isMove = true;
                    }
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
                itemPosX[(int)PlayerPos.x].itemPosY[(int)PlayerPos.y].gameObject.transform.parent.GetComponent<TileData>().isActiveself = false;
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
            GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_09);
            var color = GameFade.instance.m_image.color;
            color.a = 255;
            GameFade.instance.m_image.color = color;
            GameFade.instance.FadeOut(1);
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
            _jsonDatas = GameObject.Find("LoadData");
        var datas = _jsonDatas.GetComponent<LoadOnlyJson>();
        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = datas.tileDataList[TileNum];
                mapPosX[i].mapPosY[j].GetComponent<TileData>().tilePos = new Vector2(i, j);
                TileNum++;
            }
        }
    }

    /// <summary>
    /// 1つ前に戻る/セーブする処理
    /// </summary>
    public void TurnObjectSetList()
    {
        if (TurnNum < 0)
            return;
        else
        {
            TurnNum++;
            SetList();
        }
    }
    public void SetBeforeStageData()
    {
        if (TurnNum < 0)
            return;
        else
        {
            if(PlayerPos == _playerPosList[TurnNum -1])
            {
                return;
            }
            else
            {
                TurnNum++;
                SetList();
            }
        }
    }
    public void SetList()
    {
        if (TurnNum < _playerVecList.Count)
        {
            for (int num = _playerVecList.Count; num >= TurnNum; num--)
            {
                _playerVecList.Remove(_playerVecList[num - 1]);
                _playerPosList.Remove(_playerPosList[num - 1]);
                _isplayerRopeList.Remove(_isplayerRopeList[num - 1]);
                stageData.Remove(stageData[num - 1]);
                _stageTurnContList.Remove(_stageTurnContList[num - 1]);
            }
        }
        _jsonDatas.GetComponent<StageSave>().SaveTile();
        _playerVecList.Add(player.nowPos);
        _playerPosList.Add(PlayerPos);
        _isplayerRopeList.Add(player.isHaveRope);
        _playerRoteSpriteNumList.Add((int)player.GetComponent<Player>().dic);
        _stageTurnContList.Add(stageTurnCount);
    }
    public void LoadBeforeStageData()
    {
        if (TurnNum <= 1)
            return;
        else
        {
            TurnNum--;
            var roadTurnData = TurnNum - 1;
            _jsonDatas.GetComponent<StageSave>().OnLoad();
            player.nowPos = _playerVecList[roadTurnData];
            player.transform.localPosition = _playerVecList[roadTurnData];
            PlayerPos = _playerPosList[roadTurnData];
            player.isHaveRope = _isplayerRopeList[roadTurnData];
            player.playerPos = _playerPosList[roadTurnData];
            player.GetComponent<Player>().ChangePlayerSprite((Player.direction)_playerRoteSpriteNumList[roadTurnData]);
            stageTurnCount = _stageTurnContList[TurnNum];
        }
    }
    public void OnOneBack()
    {
        LoadBeforeStageData();
    }
}