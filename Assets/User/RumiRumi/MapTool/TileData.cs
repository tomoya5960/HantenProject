using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //�^�C���̔z����W
    public int _turnCount;
    public bool _isTurnOver;    //�^�C���̔��]�\���̗L��
    public bool _isRope;
    [SerializeField]
    private int _imageID;
    public int ImageID
    {
        get { return _imageID; }
        set {
            _imageID = value;
            SearchSetSprite(_imageID);
        } 
    }  //���݂̃C���[�WID

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        ImageID = _imageID;
    }

    /// <summary>�摜�̌����ƍ����ւ�</summary>
    public void SearchSetSprite(int _imageID)
    {
        string _name = GameManager.instance.dictionary.ImageName(_imageID); //��������摜��������
        Sprite sprite = Resources.Load<Sprite>("Textures/" + _name) as Sprite;    //��������󂯎�������O�����ƂɃt�@�C��������
        image.sprite = sprite;  //�摜�������ւ���
    }


    /// <summary>���]�ł���񐔂��K��l�ɒB�����ꍇ���]�o���Ȃ����鏈������є��]���鏈��</summary>
    public void HantenCheck()
    {
        //�Ȃ񂩂��̂����ǉ����邩���`
    }
}
