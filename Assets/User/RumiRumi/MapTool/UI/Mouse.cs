using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private GameObject clickedGameObject,ChildObject;   //�I�������^�C���Ƃ��̎q�̑I�𒆂ɕ\�������I�u�W�F�N�g
    private Image image;
    private TileData getTileData;   //�Z�b�g����^�C���̃f�[�^
    private TileData setTileData;   //����ւ���^�C���̃f�[�^�i�i�[�p�j
    private bool isChangeTile =false;  //�E���̃^�C����ύX���ɂق��̂��̂�I���ł��Ȃ��悤�ɂ�����
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
                    if (ChildObject != null)
                    {
                        ChildObject.SetActive(false);   //�ق��̑I����Ԃ̎q�I�u�W�F�N�g������ꍇ��false�ɂ���
                        ChildObject = null;
                    }
                    if (!isChangeTile)
                    {
                        clickedGameObject = hit2d.transform.gameObject; //�^�C�����i�[
                        ChildObject = clickedGameObject.transform.GetChild(0).gameObject;   //�q�I�u�W�F�N�g�i�I�����Ă���^�C���������\�����邽�߂̃I�u�W�F�N�g�j���i�[
                        ChildObject.SetActive(true);    //�����\������
                        getTileData = clickedGameObject.GetComponent<TileData>();   //�^�C���f�[�^��ǂݍ���
                    }
                }
                
                if(hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image != hit2d.transform.gameObject.GetComponent<Image>())
                {
                    if (!isChangeTile)
                        isChangeTile = true;    //�^�C����I�����A�h��n�߂Ă���ꍇ�͑��̃^�C����I���ł��Ȃ�����
                    else
                    {
                        image = clickedGameObject.GetComponent<Image>();
                        SetData(hit2d.transform.gameObject);  //�u������
                    }
                }
                else if (hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null && image == hit2d.transform.gameObject.GetComponent<Image>())
                {
                    if (!isChangeTile)
                        isChangeTile = true;
                    else
                        SetData(hit2d.transform.gameObject);  //�u������
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (isChangeTile)
                isChangeTile = false;   //���̃^�C����I���ł��Ȃ������Ԃ�����
        }
        if (Input.GetMouseButtonDown(1))
        {
            //�I�������ׂĉ���
            clickedGameObject = null;   
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
        ChildObject.SetActive(false);
        ChildObject = null;
        getTileData = null;
        setTileData = null;
    }

}
