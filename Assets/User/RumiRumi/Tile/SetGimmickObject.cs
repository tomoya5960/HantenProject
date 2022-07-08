using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGimmickObject : MonoBehaviour
{
    private Vector2 tilePos;
    void Start()
    {
        //マップツールで生成されたプレイヤーを動かないようにする
        if (SceneManager.GetActiveScene().name == "MapEditorScene")
        {
            gameObject.GetComponent<SetGimmickObject>().enabled = false;
        }
        else
        {
            tilePos = gameObject.transform.parent.GetComponent<TileData>().tilePos;
            GeneralManager.instance.mapManager.itemPosX[(int)tilePos.x].itemPosY[(int)tilePos.y] = this.gameObject;
        }
    }

}
