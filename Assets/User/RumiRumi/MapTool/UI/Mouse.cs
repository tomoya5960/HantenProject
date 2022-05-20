using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    private GameObject clickedGameObject,ChildObject;   //�I�������^�C���Ƌ����\���i�I�𒆂ɕ\�������I�u�W�F�N�g�j
    [SerializeField]
    private GameObject rope;    //���[�v�̃v���n�u���i�[
    private Image image;
    [SerializeField]
    private TileData getTileData;   //�Z�b�g����^�C���̃f�[�^
    [SerializeField]
    private TileData setTileData;   //����ւ���^�C���̃f�[�^�i�i�[�p�j
    private bool isChangeTile =false;  //�E���̃^�C����ύX���ɍ�����I���ł��Ȃ��悤�ɂ�����
    [HideInInspector]
    public bool isRope = false;  //�^�C���̏�Ƀ��[�v��u�����I�����Ă�

    private void Update()
    {
        if (Input.GetMouseButton(0))     //�N���b�N�����ꏊ�ɑI������^�C�������邩
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2d)
            {
                if (hit2d.transform.gameObject.tag == "TileData")
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

                if (hit2d.transform.gameObject.tag == "MapTile" && clickedGameObject != null)
                {
                    if (hit2d.transform.gameObject.GetComponent<TileData>()._isRope == true)
                    {
                        if (!isChangeTile)
                        {
                            SetData(hit2d.transform.gameObject);  //�u������
                            CheckRope(hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                            isChangeTile = true;    //�^�C����I�����A�h��n�߂Ă���ꍇ�͑��̃^�C����I���ł��Ȃ�����
                        }
                        else
                        {
                            SetData(hit2d.transform.gameObject);  //�u������
                            CheckRope(hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                        }
                    }

                    if (!isChangeTile)
                    {
                        SetData(hit2d.transform.gameObject);  //�u������
                        CheckRope(hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                        isChangeTile = true;    //�^�C����I�����A�h��n�߂Ă���ꍇ�͑��̃^�C����I���ł��Ȃ�����
                    }
                    else
                    {
                        image = hit2d.transform.gameObject.GetComponent<Image>();
                        SetData(hit2d.transform.gameObject);  //�u������
                        CheckRope(hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                    }

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
        setTileData._imageID = getTileData._imageID;
        if (setTileData._imageID == 2 || setTileData._imageID == 5|| setTileData._imageID == 3)
            setTileData._isTurnOver = getTileData._isTurnOver;
        setTileData._isRope = isRope;
    }

    /// <summary> �f�[�^�̃��Z�b�g </summary>
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
