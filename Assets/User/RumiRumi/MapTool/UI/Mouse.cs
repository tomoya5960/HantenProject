using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private GameObject clickedGameObject,ChildObject;   //選択したタイルと強調表示（選択中に表示されるオブジェクト）
    [SerializeField]
    private GameObject rope;    //ロープのプレハブを格納
    private Image image;
    [SerializeField]
    private TileData getTileData;   //セットするタイルのデータ
    [SerializeField]
    private TileData setTileData;   //入れ替えるタイルのデータ（格納用）
    private bool isChangeTile =false;  //右側のタイルを変更中に左側を選択できないようにするやつ
    [HideInInspector]
    public bool isRope = false;  //タイルの上にロープを置くか選択してね

    private void Update()
    {
        if (Input.GetMouseButton(0))     //クリックした場所に選択するタイルがあるか
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2d)
            {
                if (hit2d.transform.gameObject.tag == "TileData")
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

                if (hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null)
                {
                    if (hit2d.transform.gameObject.GetComponent<TileData>()._isRope == true)
                    {
                        if (!isChangeTile)
                        {
                            SetData(hit2d.transform.gameObject);  //置き換え
                            CheckRope(hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                            isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                        }
                        else
                        {
                            SetData(hit2d.transform.gameObject);  //置き換え
                            CheckRope(hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        }
                    }

                    if (!isChangeTile)
                    {
                        SetData(hit2d.transform.gameObject);  //置き換え
                        CheckRope(hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                        isChangeTile = true;    //タイルを選択し、塗り始めている場合は他のタイルを選択できなくする
                    }
                    else
                    {
                        image = hit2d.transform.gameObject.GetComponent<Image>();
                        SetData(hit2d.transform.gameObject);  //置き換え
                        CheckRope(hit2d.transform.gameObject);  //ロープがあるか確認、なければ追加、いらなければ削除
                    }

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
        setTileData._imageID = getTileData._imageID;
        if (setTileData._imageID == 2 || setTileData._imageID == 5|| setTileData._imageID == 3)
            setTileData._isTurnOver = getTileData._isTurnOver;
        setTileData._isRope = isRope;
    }

    /// <summary> データのリセット </summary>
    private void RisetData()
    {
        ChildObject.SetActive(false);
        ChildObject = null;
        getTileData = null;
        setTileData = null;
    }

    private void CheckRope(GameObject _hit2d)
    {
        if (isRope && _hit2d.gameObject.transform.childCount == 0 &&
           (setTileData._imageID == 1 || setTileData._imageID == 2 || setTileData._imageID == 3))
        {
            var setChild = (GameObject)Instantiate(rope, new Vector3(0, 0, 0), Quaternion.identity, _hit2d.transform);
            setChild.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (!isRope && _hit2d.gameObject.transform.childCount != 0)
        {
            Destroy(_hit2d.transform.GetChild(0).gameObject);
        }
    }
}
