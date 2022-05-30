using UnityEngine;
using UnityEngine.UI;

public class EdiotTileData : MonoBehaviour
{
    #region �^�C���f�[�^�̒��g
    private      Image �@�@ image;              �@  //���݂̃C���[�WID���i�[�����
    [SerializeField]
    private int             _imageID        = 0;
    public  bool            isTurnOver      = true;    //�^�C���̔��]�\���̗L��
    private bool            isEnableRope    = false;   //���̃^�C���Ƀ��[�v�������Ă��邩
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

    public bool _isEnableRope
    {
        get { return isEnableRope; }
        set
        {
            isEnableRope = value;
            //�q�I�u�W�F�N�g������i���[�v�I�u�W�F�N�g������j�ꍇ�̂ݏ���
            if (_child != null)
            {
                if (isEnableRope && _imageID == 2)   //���[�v�������āA���[�v�̕\�����I�t�S���Ă�����\������
                    _child.SetActive(true);

                else
                    _child.SetActive(false);
            }
            else
            {
                if (isEnableRope && _imageID == 2)
                    SearchSetRope();
                else
                    isEnableRope = false;
            }
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
        GeneralManager.Instance.mapType.imageName = (MapType.ImageIdType)imageID;
        string _name = GeneralManager.Instance.mapType.imageName.ToString();
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
}
