using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    #region　ステージで必須な物
    [Header("反転可能数")]
    public  int               stageTurnCount      = 0;  //反転できる残りの回数
    private string            _stageName          = ""; //JsonOnlyJsonのステージ名を格納する
    private        GameObject _loadJson;      //_loadOnlyJson取得するために使うやーつ
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
    public int selectStageNum = 0;  //ステージ番号を格納
    #endregion

    private void Awake()
    {
        if (GameObject.Find("LoadData"))
            _loadJson = GameObject.Find("LoadData");
        _stageName = SceneManager.GetActiveScene().name;
        if (_loadJson != null)
        {
            _loadJson.GetComponent<LoadOnlyJson>().loadFileName = _stageName;
        }
        else
            _stageName = "エディターで編集中";
    }

    private void Start()
    {
        if (_loadJson != null)
        {
            SetTileArray();
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
        {
            Debug.Log("反転できません");
        }
    }

    /// <summary>
    /// tileDataListのオブジェクトを二次元配列に再整列する関数
    /// </summary>
    private void SetTileArray()
    {
        var TileNum = 0;
        for (int i = 0; i <= 6; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                mapPosX[i].mapPosY[j] = _loadJson.GetComponent<LoadOnlyJson>().tileDataList[TileNum];
                TileNum++;
            }
        }
    }
}
