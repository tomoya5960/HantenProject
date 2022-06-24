using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    #region �^�C���f�[�^�֘A
    private EdiotTileData _sample_tile_data;                //���{�̃^�C���f�[�^
    private EdiotTileData _mapTileData;                     //����ւ���}�b�v�^�C���f�[�^�i�i�[�p�j
    private GameObject _clickedGameObject,_childObject;     //�I�������^�C���Ƌ����\���i�I�𒆂ɕ\�������I�u�W�F�N�g�j
    private Image _image;
    #endregion

    #region ���ۂ̑���֘A
    private bool            _isChangeTile =false;   //�E���̃^�C����ύX���ɍ�����I���ł��Ȃ��悤�ɂ�����
    private      GameObject _rope;                  //���[�v�̃v���n�u���i�[
    private      GameObject _stone;
    [HideInInspector]
    public bool             isRope = false;         //�^�C���̏�Ƀ��[�v��u�����I�����Ă�
    [HideInInspector]
    public bool             isStone = false;         //�^�C���̏�Ɋ��u�����I�����Ă�
    #endregion

    private void Awake()
    {
        _rope = (GameObject)Resources.Load("Prefabs/Rope");
        _stone = (GameObject)Resources.Load("Prefabs/Stone");
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))     //�N���b�N�����ꏊ�ɑI������^�C�������邩
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Hit2d = Physics2D.Raycast((Vector2)Ray.origin, (Vector2)Ray.direction);

            if (Hit2d)
            {
                if (Hit2d.transform.gameObject.tag == "TileData")
                {
                    if (_childObject != null)
                    {
                        _childObject.SetActive(false);   //�ق��̑I����Ԃ̎q�I�u�W�F�N�g������ꍇ��false�ɂ���
                        _childObject = null;
                    }
                    if (!_isChangeTile)
                    {
                        _clickedGameObject = Hit2d.transform.gameObject; //�^�C�����i�[
                        _childObject = _clickedGameObject.transform.GetChild(0).gameObject;   //�q�I�u�W�F�N�g�i�I�����Ă���^�C���������\�����邽�߂̃I�u�W�F�N�g�j���i�[
                        _childObject.SetActive(true);    //�����\������
                        _sample_tile_data = _clickedGameObject.GetComponent<EdiotTileData>();   //�^�C���f�[�^��ǂݍ���
                    }
                }

                if (Hit2d.transform.gameObject.tag == "MapTile" && _clickedGameObject != null)
                {
                    if (Hit2d.transform.gameObject.GetComponent<EdiotTileData>().isEnableRope == true)
                    {
                        if (!_isChangeTile)
                        {
                            SetData(Hit2d.transform.gameObject);  //�u������
                            CheckRope(Hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                            CheckStone(Hit2d.transform.gameObject);
                            _isChangeTile = true;    //�^�C����I�����A�h��n�߂Ă���ꍇ�͑��̃^�C����I���ł��Ȃ�����
                        }
                        else
                        {
                            SetData(Hit2d.transform.gameObject);  //�u������
                            CheckRope(Hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                            CheckStone(Hit2d.transform.gameObject);
                        }
                    }

                    if (!_isChangeTile)
                    {
                        SetData(Hit2d.transform.gameObject);  //�u������
                        CheckRope(Hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                        CheckStone(Hit2d.transform.gameObject);
                        _isChangeTile = true;    //�^�C����I�����A�h��n�߂Ă���ꍇ�͑��̃^�C����I���ł��Ȃ�����
                    }
                    else
                    {
                        _image = Hit2d.transform.gameObject.GetComponent<Image>();
                        SetData(Hit2d.transform.gameObject);  //�u������
                        CheckRope(Hit2d.transform.gameObject);  //���[�v�����邩�m�F�A�Ȃ���Βǉ��A����Ȃ���΍폜
                        CheckStone(Hit2d.transform.gameObject);
                    }
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (_isChangeTile)
                _isChangeTile = false;   //���̃^�C����I���ł��Ȃ������Ԃ�����
        }

        if (Input.GetMouseButtonDown(1))    //�I�������ׂĉ���
        {
            
            _clickedGameObject = null;   
            RisetData();
        }
    }

    /// <summary> 
    /// �f�[�^�̒u������ 
    /// </summary>
    private void SetData(GameObject _hit2d)
    {
        _mapTileData = _hit2d.GetComponent<EdiotTileData>();
        _mapTileData.imageID = _sample_tile_data.imageID;
        if (_mapTileData.imageID == 2 || _mapTileData.imageID == 5|| _mapTileData.imageID == 3)
            _mapTileData.isTurnOver = _sample_tile_data.isTurnOver;
      
        _mapTileData.isEnableProceed = _sample_tile_data.isEnableProceed;
        _mapTileData.isEnableRope = isRope;
        _mapTileData.isEnableStone = isStone;
    }

    /// <summary> �f�[�^�̃��Z�b�g </summary>
    private void RisetData()
    {
        _childObject.SetActive(false);
        _childObject = null;
        _sample_tile_data = null;
        _mapTileData = null;
    }

    /// <summary>
    /// ���[�v���q�ɐ���
    /// </summary>
    /// <param name="_hit2d"></param>
    private void CheckRope(GameObject _hit2d)
    {

        if (isRope && _hit2d.gameObject.transform.childCount == 0 &&_mapTileData.imageID == 2)
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Stone")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
            var SetChild = (GameObject)Instantiate(_rope, new Vector3(0, 0, 0), Quaternion.identity, _hit2d.transform);
            SetChild.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (!isRope|| _mapTileData.imageID != 2)
        {
            for(int num = 0;num < _hit2d.transform.childCount;num++)
            {
                if(_hit2d.transform.GetChild(num).gameObject.tag == "Rope")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
    }

    /// <summary>
    /// ����q�ɐ���
    /// </summary>
    /// <param name="_hit2d"></param>
    private void CheckStone(GameObject _hit2d)
    {
        if (isStone && _hit2d.gameObject.transform.childCount == 0 && (_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
             for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Rope")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
            var SetChild = (GameObject)Instantiate(_stone, new Vector3(0, 0, 0), Quaternion.identity, _hit2d.transform);
            SetChild.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else if (!isStone || !(_mapTileData.imageID == 1 || _mapTileData.imageID == 2 || _mapTileData.imageID == 3))
        {
            for (int num = 0; num < _hit2d.transform.childCount; num++)
            {
                if (_hit2d.transform.GetChild(num).gameObject.tag == "Stone")
                    Destroy(_hit2d.transform.GetChild(num).gameObject);
            }
        }
    }
}
