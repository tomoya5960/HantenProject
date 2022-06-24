using UnityEngine;
using UnityEngine.UI;

public class EdiotTileData : MonoBehaviour
{
    #region �^�C���f�[�^�̒��g
    private      Image �@�@ image;              �@  //���݂̃C���[�WID���i�[�����
    [SerializeField]
    private int             _imageID        = 0;
    public  bool            isTurnOver      = true;    //�^�C���̔��]�\���̗L��
    private bool           _isEnableRope    = false;   //���̃^�C���Ƀ��[�v�������Ă��邩
    private bool           _isEnableStone = false;
    private  int            _childCount     = 0;       //�q�I�u�W�F�N�g�̂���
    public  bool            isEnableProceed = true;        //�ʂ邱�Ƃ��ł��邩
    private      GameObject _child       = null;       //�q�I�u�W�F�N�g�̊i�[
    #endregion

    public int imageID
    {
        get { return _imageID; }
        set
        {
            _imageID = value;
            SearchSetSprite(_imageID);
        }
    }
    public bool isEnableRope
    {
        get { return _isEnableRope; }
        set
        {
            _isEnableRope = value;
            if (_isEnableRope && _imageID == 2)
                SearchSetRope();

        }
    }
    public bool isEnableStone
    {
        get { return _isEnableStone; }
        set
        {
            _isEnableStone = value;
            if (_isEnableStone && (_imageID == 1 || _imageID == 2 || _imageID == 3))
                SearchSetStone();
        }
    }


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        _imageID = imageID;
        _childCount = transform.childCount;
        if (_childCount == 0 && isEnableRope)
        {
            SearchSetRope();
        }
        else if(_childCount == 0 && isEnableStone)
        {
            SearchSetStone();
        }
        else if (_childCount != 0)
            _child = transform.GetChild(0).gameObject;
        else
            _child = null;
    }

    /// <summary>
    /// �摜�̌����ƍ����ւ�
    /// </summary>
    public void SearchSetSprite(int imageID)
    {
        GeneralManager.instance.mapType.imageName = (MapType.ImageIdType)imageID;
        string _name = GeneralManager.instance.mapType.imageName.ToString();
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //��������󂯎�������O�����ƂɃt�@�C��������
        image.sprite = sprite;  //�摜�������ւ���
    }

    /// <summary>
    /// ���[�v�̉摜���������A�i�[����֐�
    /// </summary>
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        if (prefabObj == null)
        {
            Debug.LogError($"<color=yellow>Prefabs/Rope ���Ȃ���</color>");
            return;
        }
        else
        {
            GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
            _child = prefab;
        }
    }

    public void SearchSetStone()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Stone");
        if (prefabObj == null)
        {
            Debug.LogError($"<color=yellow>Prefabs/Stone ���Ȃ���</color>");
            return;
        }
        else
        {
            GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
            _child = prefab;
        }
    }
}
