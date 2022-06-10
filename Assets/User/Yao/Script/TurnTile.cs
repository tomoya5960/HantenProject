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
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);


            if (Hit2d)
            {
                if (Hit2d.transform.gameObject.tag == "MapTile")
                {
                    TurnTileList.Add(Hit2d.transform.gameObject);
                    emphasisTile = Hit2d.transform.GetChild(0).gameObject;
                    emphasisTile.gameObject.SetActive(true);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
            Turn();

    }


    void Turn()
    {
        foreach (var tile in TurnTileList)
        {
            tile.gameObject.GetComponent<TileMaster>().TurnImage();
            tile.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
