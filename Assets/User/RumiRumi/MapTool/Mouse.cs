using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public GameObject clickedGameObject;
    private Image image;
    private TileData getTileData;   //�Z�b�g����^�C���̃f�[�^
    private TileData setTileData;   //����ւ���^�C���̃f�[�^�i�i�[�p�j
    private void Update()
    {
        if (Input.GetMouseButton(0))     //�N���b�N�����ꏊ�ɑI������^�C�������邩
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2d)
            {
                if (hit2d.transform.gameObject.tag == "TileData" && clickedGameObject != hit2d.transform.gameObject)
                {
                    clickedGameObject = hit2d.transform.gameObject;
                    getTileData = clickedGameObject.GetComponent<TileData>();
                }
                
                if(hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image != hit2d.transform.gameObject.GetComponent<Image>())
                {
                    image = clickedGameObject.GetComponent<Image>();
                    SetData(hit2d.transform.gameObject);  //�u������
                }
                else if (hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image == hit2d.transform.gameObject.GetComponent<Image>())
                {
                    SetData(hit2d.transform.gameObject);  //�u������
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            clickedGameObject = null;   //�I��������
            RisetData();
        }
    }

    /// <summary> �f�[�^�̒u������ </summary>
    private void SetData(GameObject _hit2d)
    {
        
        setTileData = _hit2d.GetComponent<TileData>();
        setTileData._isTurnOver = getTileData._isTurnOver;
        setTileData._turnCount = getTileData._turnCount;
        setTileData._isRope = getTileData._isRope;
        setTileData.ImageID = getTileData.ImageID;
    }

    /// <summary> �f�[�^�̃��Z�b�g </summary>
    private void RisetData()
    {
        getTileData = null;
        setTileData = null;
    }

}
