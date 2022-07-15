using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnTile : MonoBehaviour
{
    private GameObject _choiceTile, _choiceTileDir, emphasisTile;

    [SerializeField]
    private List<GameObject> TurnTileList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))     //ÉNÉäÉbÉNÇµÇΩèÍèäÇ…ëIëÇ∑ÇÈÉ^ÉCÉãÇ™Ç†ÇÈÇ©
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);


            if (Hit2d)
            {
                if (Hit2d.transform.gameObject.tag == "MapTile")
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

                                void Turn()
                                {
                                    bool doTurn = true;
                                    //Ç‡Çµï˚äpÇ™íËÇ‹ÇÁÇ∏Ç…îΩì]Ç∑ÇÈèÍèäÇ™å©Ç¬Ç©ÇÁÇ»Ç©Ç¡ÇΩÇÁîΩì]ÇπÇ∏Ç…èàóùÇî≤ÇØÇÈ
                                    if (_choiceTileDir != null) doTurn = false;

                                    TurnTileList = TurnTileList.Distinct().ToList();

                                    foreach (var tile in TurnTileList)
                                    {
                                        tile.transform.GetChild(0).gameObject.SetActive(true);
                                    }
                                }

                                // xÇ∆yÇ™Ç«ÇøÇÁÇ©ï–ï˚ÇæÇØìØàÍÇ≈Ç†ÇÈèÍçáÇÃèàóù
                                _choiceTileDir = Hit2d.transform.gameObject;
                                TurnTileList.Add(Hit2d.transform.gameObject);
                                emphasisTile = Hit2d.transform.GetChild(0).gameObject;
                                emphasisTile.gameObject.SetActive(true);

                                //_choiceTileÇ∆_choiceTileDirÇÃxÇ∆yÇÃÇ«ÇøÇÁÇ™ìØÇ∂Ç©îªíËÇ∑ÇÈ
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
                                            if (tileArray[i].transform.localPosition.x != _choiceTile.transform.localPosition.x) continue;
                                            TurnTileList.Add(tileArray[i].gameObject);
                                            emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                            emphasisTile.gameObject.SetActive(true);
                                        }
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
                                            if (tileArray[i].transform.localPosition.y != _choiceTile.transform.localPosition.y) continue;
                                            TurnTileList.Add(tileArray[i].gameObject);
                                            emphasisTile = tileArray[i].transform.GetChild(0).gameObject;
                                            emphasisTile.gameObject.SetActive(true);
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
            Turn();
            _choiceTile = null;
            _choiceTileDir = null;
        }

    }


    void Turn()
    {
        bool doTurn = false;
        //Ç‡Çµï˚äpÇ™íËÇ‹ÇÁÇ∏Ç…îΩì]Ç∑ÇÈèÍèäÇ™å©Ç¬Ç©ÇÁÇ»Ç©Ç¡ÇΩÇÁîΩì]ÇπÇ∏Ç…èàóùÇî≤ÇØÇÈ
        if (_choiceTileDir != null) doTurn = true;

        TurnTileList = TurnTileList.Distinct().ToList();

        foreach (var tile in TurnTileList)
        {

            if (doTurn) tile.gameObject.GetComponent<TileMaster>().TurnImage();
            tile.transform.GetChild(0).gameObject.SetActive(false);
        }
    }


}
