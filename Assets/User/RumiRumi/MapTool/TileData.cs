using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //�^�C���̔z����W
    public bool _isTurnOver;    //�^�C���̔��]�\���̗L��
    [SerializeField]
    public bool isRope;     //���[�v�̗L��

    [SerializeField]
    private int imageID;
    private int _objectCount;
    private GameObject child;   //�q�I�u�W�F�N�g�̊i�[
    public int _imageID
    {
        get { return imageID; }
        set
        {
            imageID = value;
            SearchSetSprite(imageID);
        }
    }  //���݂̃C���[�WID

    private Image image;

    public bool _isRope
    {
        get { return isRope; }
        set
        {
            isRope = value;
            //�q�I�u�W�F�N�g������i���[�v�I�u�W�F�N�g������j�ꍇ�̂ݏ���
            if (child != null)
            {
                if (isRope && (_imageID == 1 || _imageID == 2 || _imageID == 3))   //���[�v�������āA���[�v�̕\�����I�t�S���Ă�����\������
                {
                    child.SetActive(true);
                }
                else
                {
                    child.SetActive(false);
                }
            }
            else
            {
                if (_objectCount == 0 && isRope && (_imageID == 1 || _imageID == 2 || _imageID == 3))
                {
                    SearchSetRope();
                }
                else
                {
                    isRope = false;
                }
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
        _objectCount = transform.childCount;
        if(_objectCount == 0 && isRope)
        {
            SearchSetRope();
        }
        else if (_objectCount != 0)
            child = transform.GetChild(0).gameObject;
        else
            child =  null;
    }

    /// <summary>�摜�̌����ƍ����ւ�</summary>
    public void SearchSetSprite(int imageID)
    {
        string _name = GameManager.instance.dictionary.ImageName(imageID); //��������摜��������
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //��������󂯎�������O�����ƂɃt�@�C��������
        image.sprite = sprite;  //�摜�������ւ���
    }
    public void SearchSetRope()
    {
        GameObject prefabObj = (GameObject)Resources.Load("Prefabs/Rope");
        GameObject prefab = (GameObject)Instantiate(prefabObj, transform.position, Quaternion.identity, transform);
        child = prefab;
    }
}
