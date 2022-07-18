using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            if (TurnTileList.Count > 0)
                GeneralManager.instance.isEnablePlay = false;
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
            if (GeneralManager.instance.mapManager.stageTurnCount > 0 && GeneralManager.instance.mapManager.player.GetComponent<PlayerManager>().isPlayerMove == false)
            {
                Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);
                if (Hit2d)
                {
                    if (Hit2d.transform.gameObject.tag == "MapTile")
                    {
                        if (Hit2d.transform.gameObject.GetComponent<TileData>().imageID != 0)
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
                                        if (Hit2d.transform.gameObject.GetComponent<TileData>().imageID != 0)
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
                                            TileData[] tileArray = parent.GetComponentsInChildren<TileData>();
                                            if (tileArray != null)
                                            {
                                                for (int i = 0; i < tileArray.Length; i++)
                                                {
                                                    if (tileArray[i].GetComponent<TileData>().imageID != 0)
                                                    {
                                                        if (tileArray[i].transform.localPosition.x != _choiceTile.transform.localPosition.x) continue;
                                                        TurnTileList.Add(tileArray[i].gameObject);
                                                        emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                                        emphasisTile.gameObject.SetActive(true);
                                                    }
                                                }
                                                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_06);
                                            }
                                        }
                                        if (sameIsY)
                                        {
                                            var parent = _choiceTile.transform.parent.gameObject;
                                            TileData[] tileArray = parent.GetComponentsInChildren<TileData>();
                                            if (tileArray != null)
                                            {
                                                for (int i = 0; i < tileArray.Length; i++)
                                                {
                                                    if (tileArray[i].GetComponent<TileData>().imageID != 0)
                                                    {
                                                        if (tileArray[i].transform.localPosition.y != _choiceTile.transform.localPosition.y) continue;
                                                        TurnTileList.Add(tileArray[i].gameObject);
                                                        emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                                        emphasisTile.gameObject.SetActive(true);
                                                    }
                                                }
                                                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_06);
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
            GeneralManager.instance.isEnablePlay = true;
            playerObject = GeneralManager.instance.mapManager.mapPosX[(int)GeneralManager.instance.mapManager.PlayerPos.x].mapPosY[(int)GeneralManager.instance.mapManager.PlayerPos.y];
            if (TurnTileList.Count <= 1 || TurnTileList.Contains(playerObject))
            {
                firstTile = null;
                _choiceTile = null;
                _choiceTileDir = null;
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
            }
            else if (GeneralManager.instance.mapManager.stageTurnCount > 0)
            {
                Turn();
                GeneralManager.instance.mapManager.TurnObjectSetList();
                GeneralManager.instance.mapManager.stageTurnCount--;
                GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_11);
            }
            TurnTileList.Clear();
            TurnTileList = new List<GameObject>();
        }


        void Turn()
        {
            bool doTurn = false;
            //もし方角が定まらずに反転する場所が見つからなかったら反転せずに処理を抜ける
            if (_choiceTileDir != null) doTurn = true;
            TurnTileList = TurnTileList.Distinct().ToList();
            foreach (var tile in TurnTileList)
            {
                tile.gameObject.GetComponent<TileMaster>().TurnImage();
                for (int num = 0; num < tile.transform.gameObject.transform.childCount; num++)
                {
                    if (tile.transform.GetChild(num).gameObject.name == "Select")
                    {
                        if (doTurn) tile.gameObject.GetComponent<TileMaster>().TurnImage();
                        emphasisTile = tile.transform.GetChild(num).gameObject;
                    }
                }
                emphasisTile.gameObject.SetActive(false);
            }
        }
    }
}
