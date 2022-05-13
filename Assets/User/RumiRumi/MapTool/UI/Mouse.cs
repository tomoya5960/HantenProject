using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private GameObject clickedGameObject,ChildObject;   //選択肢たタイルとその子の選択中に表示されるオブジェクト
    private Image image;
    private TileData getTileData;   //セットするタイルのデータ
    private TileData setTileData;   //入れ替えるタイルのデータ（格納用）
    private bool isChangeTile =false;  //右側のタイルを変更中にほかのものを選択できないようにするやつ
    private void Update()
    {
        if (Input.GetMouseButton(0))     //クリックした場所に選択するタイルがあるか
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2d)
            {
                if (hit2d.transform.gameObject.tag == "TileData" && clickedGameObject != hit2d.transform.gameObject)
                {
                    if (ChildObject != null)
                    {
                        ChildObject.SetActive(false);   //ほかの選択状態の子オブジェクトがある場合はfalseにする
                        ChildObject = null;
                    }
                    if (!isChangeTile)
                    {
                        clickedGameObject = hit2d.transform.gameObject; //タイルを格納
                        ChildObject = clickedGameObject.transform.GetChild(0).gameObject;   //子オブジェクト（選択しているタイルを強調表示するためのオブジェクト）を格納
                        ChildObject.SetActive(true);    //強調表示する
                        getTileData = clickedGameObject.GetComponent<TileData>();   //タイルデータを読み込み
                    }
                }
                
                if(hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image != hit2d.transform.gameObject.GetComponent<Image>())
                {
                    if (!isChangeTile)
                        isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                    else
                    {
                        image = clickedGameObject.GetComponent<Image>();
                        SetData(hit2d.transform.gameObject);  //置き換え
                    }
                }
                else if (hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image == hit2d.transform.gameObject.GetComponent<Image>())
                {
                    if (!isChangeTile)
                        isChangeTile = true;
                    else
                        SetData(hit2d.transform.gameObject);  //置き換え
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (isChangeTile)
                isChangeTile = false;   //他のタイルを選択できなくする状態を解除
        }
        if (Input.GetMouseButtonDown(1))
        {
            //選択をすべて解除
            clickedGameObject = null;   
            RisetData();
        }
    }

    /// <summary> データの置き換え </summary>
    private void SetData(GameObject _hit2d)
    {
        
        setTileData = _hit2d.GetComponent<TileData>();
        setTileData._isTurnOver = getTileData._isTurnOver;
        setTileData._turnCount = getTileData._turnCount;
        setTileData._isRope = getTileData._isRope;
        setTileData.ImageID = getTileData.ImageID;
    }

    /// <summary> データのリセット </summary>
    private void RisetData()
    {
        ChildObject.SetActive(false);
        ChildObject = null;
        getTileData = null;
        setTileData = null;
    }

}
