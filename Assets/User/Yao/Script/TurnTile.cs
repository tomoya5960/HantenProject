using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTile : MonoBehaviour
{
    private GameObject _choiceTile, emphasisTile;

    [SerializeField]
    private List<GameObject> TurnTileList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))     //クリックした場所に選択するタイルがあるか
        {
            if(TurnTileList.Count > 0)
                GeneralManager.instance.isEnablePlay = false;
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
                            TurnTileList.Add(Hit2d.transform.gameObject);
                            
                            for (int num = 0; num < Hit2d.transform.gameObject.transform.childCount; num++)
                            {
                                if (Hit2d.transform.GetChild(num).gameObject.name == "Player" || Hit2d.transform.GetChild(num).gameObject.name == "Rope" || Hit2d.transform.GetChild(num).gameObject.name == "Stone")
                                    return;
                                if (Hit2d.transform.GetChild(num).gameObject.name == "Select")
                                {
                                    Hit2d.transform.GetChild(num).gameObject.SetActive(true);
                                    GeneralManager.instance.soundManager.PlaySE(SoundManager.SeName.se_06);
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
            if (GeneralManager.instance.mapManager.stageTurnCount > 0 && TurnTileList.Count > 0)
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
            foreach (var tile in TurnTileList)
            {
                tile.gameObject.GetComponent<TileMaster>().TurnImage();
                for (int num = 0; num < tile.transform.gameObject.transform.childCount; num++)
                {
                    if (tile.transform.GetChild(num).gameObject.name == "Select")
                    {
                        emphasisTile = tile.transform.GetChild(num).gameObject;
                    }
                }
                emphasisTile.gameObject.SetActive(false);
            }
        }
    }
}
