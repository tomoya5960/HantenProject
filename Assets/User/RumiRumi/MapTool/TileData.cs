using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _arrayPos;   //�^�C���̔z����W
    public int _turnCount;      
    public bool _isTurnOver;    //�^�C���̔��]�\���̗L��
    public bool _isRope;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    /// <summary>���]�ł���񐔂��K��l�ɒB�����ꍇ���]�o���Ȃ����鏈��</summary>
    public void HantenCheck()
    {
        //�Ȃ񂩂��̂����ǉ����邩���`
    }
}
