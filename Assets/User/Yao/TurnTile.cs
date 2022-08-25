using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.SceneManagement;

public class TurnTile : MonoBehaviour
{
    private GameObject _choiceTile, _choiceTileDir, emphasisTile, playerObject;

    [SerializeField]
    private List<GameObject> TurnTileList = new List<GameObject>();
    GameObject firstTile;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);
            if (Hit2d)
            {
                if (Hit2d.transform.gameObject.tag == "MapTile")
                {
                    firstTile = Hit2d.transform.gameObject;
                }
            }
        }
        if (Input.GetMouseButton(0))     //クリックした場所に選択するタイルがあるか
        {
            if (StageManager.Instance.hantenNum > 0 && StageManager.Instance.isPlayerMove == false)
            {
                Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);
                if (Hit2d)
                {
                    if (Hit2d.transform.gameObject.tag == "MapTile")
                    {
                        GeneralManager.Instance.isPlay = false;
                        if (Hit2d.transform.gameObject.GetComponent<MapTile>().tileId != 0)
                        {
                            if (_choiceTile == null)
                            {
                                _choiceTile = Hit2d.transform.gameObject;
                                TurnTileList.Add(Hit2d.transform.gameObject);
                                emphasisTile = Hit2d.transform.GetChild(0).gameObject;
                                emphasisTile.gameObject.SetActive(true);

                            }
                            else
                            {
                                if (_choiceTile != Hit2d.transform.gameObject)
                                {
                                    if (!(_choiceTile.transform.localPosition.x != Hit2d.transform.localPosition.x
                                        && _choiceTile.transform.localPosition.y != Hit2d.transform.localPosition.y))
                                    {
                                        if (_choiceTileDir != null)
                                        {
                                            if (!(Hit2d.transform.localPosition.x == _choiceTileDir.transform.localPosition.x
                                          || Hit2d.transform.localPosition.y == _choiceTileDir.transform.localPosition.y))
                                            {
                                                for (int i = TurnTileList.Count - 1; i >= 0; i--)
                                                {
                                                    var obj = TurnTileList[i];
                                                    if (_choiceTile == obj) continue;
                                                    TurnTileList.Remove(obj);
                                                    emphasisTile = obj.transform.GetChild(0).gameObject;
                                                    emphasisTile.gameObject.SetActive(false);
                                                }

                                            }
                                        }
                                        //invisible以外で xとyがどちらか片方だけ同一である場合の処理
                                        if (Hit2d.transform.gameObject.GetComponent<MapTile>().tileId != 0)
                                        {
                                            _choiceTileDir = Hit2d.transform.gameObject;
                                            TurnTileList.Add(Hit2d.transform.gameObject);
                                            emphasisTile = Hit2d.transform.GetChild(0).gameObject;
                                            emphasisTile.gameObject.SetActive(true);
                                        }
                                        //_choiceTileと_choiceTileDirのxとyのどちらが同じか判定する
                                        bool sameIsX = false;
                                        bool sameIsY = false;
                                        if (_choiceTileDir.transform.localPosition.x == _choiceTile.transform.localPosition.x) sameIsX = true;
                                        if (_choiceTileDir.transform.localPosition.y == _choiceTile.transform.localPosition.y) sameIsY = true;
                                        if (sameIsX)
                                        {
                                            var parent = _choiceTile.transform.parent.gameObject;
                                            MapTile[] tileArray = parent.GetComponentsInChildren<MapTile>();
                                            if (tileArray != null)
                                            {
                                                for (int i = 0; i < tileArray.Length; i++)
                                                {
                                                    if (tileArray[i].GetComponent<MapTile>().tileId != 0)
                                                    {
                                                        if (tileArray[i].transform.localPosition.x != _choiceTile.transform.localPosition.x) continue;
                                                        TurnTileList.Add(tileArray[i].gameObject);
                                                        emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                                        emphasisTile.gameObject.SetActive(true);
                                                    }
                                                }
                                                GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_06);
                                            }
                                        }
                                        if (sameIsY)
                                        {
                                            var parent = _choiceTile.transform.parent.gameObject;
                                            MapTile[] tileArray = parent.GetComponentsInChildren<MapTile>();
                                            if (tileArray != null)
                                            {
                                                for (int i = 0; i < tileArray.Length; i++)
                                                {
                                                    if (tileArray[i].GetComponent<MapTile>().tileId != 0)
                                                    {
                                                        if (tileArray[i].transform.localPosition.y != _choiceTile.transform.localPosition.y) continue;
                                                        TurnTileList.Add(tileArray[i].gameObject);
                                                        emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                                        emphasisTile.gameObject.SetActive(true);
                                                    }
                                                }
                                                GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_06);
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {

            firstTile = null;
            _choiceTile = null;
            _choiceTileDir = null;
            playerObject = StageManager.Instance.mapManager.mapTiles[StageManager.Instance.playerArrayPos.x,StageManager.Instance.playerArrayPos.y];
            if (TurnTileList.Count <= 1 || TurnTileList.Contains(playerObject))
            {
                foreach (var tile in TurnTileList)
                {
                    for (int num = 0; num < tile.transform.gameObject.transform.childCount; num++)
                    {
                        if (tile.transform.GetChild(num).gameObject.name == "Select")
                        {
                            tile.transform.GetChild(num).gameObject.SetActive(false);
                            emphasisTile = tile.transform.GetChild(num).gameObject;
                        }
                    }
                    emphasisTile.gameObject.SetActive(false);
                }
                GeneralManager.Instance.isPlay = true;
            }
            else if (StageManager.Instance.hantenNum > 0)
            {
                Turn();
            }
            TurnTileList.Clear();
            TurnTileList = new List<GameObject>();
        }


        void Turn()
        {
            bool doTurn = false;
            //もし方角が定まらずに反転する場所が見つからなかったら反転せずに処理を抜ける
            if (_choiceTileDir != null) doTurn = true;

            bool checkTurn = false;
            TurnTileList = TurnTileList.Distinct().ToList();
            foreach (var tile in TurnTileList)
            {
                if(!checkTurn && (tile.GetComponent<MapTile>().tileId == (TileTypeId)1 || tile.GetComponent<MapTile>().tileId == (TileTypeId)3 || 
                                  tile.GetComponent<MapTile>().tileId == (TileTypeId)7 || tile.GetComponent<MapTile>().tileId == (TileTypeId)8 || tile.GetComponent<MapTile>().tileId == (TileTypeId)9))
                {
                    checkTurn = true;
                }
            }
            if (checkTurn)
            {
                foreach (var tile in TurnTileList)
                {
                    tile.gameObject.GetComponent<TileMaster>().Hanten();
                    for (int num = 0; num < tile.transform.gameObject.transform.childCount; num++)
                    {
                        if (tile.transform.GetChild(num).gameObject.name == "Select")
                        {
                            tile.transform.GetChild(num).gameObject.SetActive(false);
                            emphasisTile = tile.transform.GetChild(num).gameObject;
                        }
                    }
                    emphasisTile.gameObject.SetActive(false);
                }
                StageManager.Instance.hantenNum--;
                StageManager.Instance.mapManager.SaveTurnData();
                GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_11);
                
                GeneralManager.Instance.isPlay = true;
            }
            else
            {
                foreach (var tile in TurnTileList)
                {
                    for (int num = 0; num < tile.transform.gameObject.transform.childCount; num++)
                    {
                        if (tile.transform.GetChild(num).gameObject.name == "Select")
                        {
                            tile.transform.GetChild(num).gameObject.SetActive(false);
                            emphasisTile = tile.transform.GetChild(num).gameObject;
                        }
                    }
                    emphasisTile.gameObject.SetActive(false);
                    GeneralManager.Instance.isPlay = true;
                }
                TurnTileList.Clear();
                TurnTileList = new List<GameObject>();
            }
        }
    }
}