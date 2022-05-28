using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileMaster : MonoBehaviour
{
    private enum TurnFaceType   //���݂̃^�C���̏�ԁi�\���j
    {
        Front = 0,
        Back,
        Goal
    }
    [SerializeField]
    private List<Sprite> _spriteLists = new List<Sprite>(); //�^�C���̃C���[�W�摜�i�\���j

    private bool _isEnableTurn = true;  //���݂̃^�C�������Ԃ��邩�ȁ[�H�itrue�̎����Ԃ����Ƃ��o����j
    public bool IsEnableTurn => _isEnableTurn;  //�O������ǂݎ��p�̂�[��

    private bool _eternalTurn = false;  //�̂��قǃJ�E���g�łł���悤��int�ɕύX���邱��

    private Image _mapImage = null;

    private TurnFaceType _turnFaceType = TurnFaceType.Front;    //�������ꂽ�Ƃ��ɕ\�̏�Ԃɂ����
    public int EnableCount = 0; //���]�ł���c���

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="first">�\�̉摜</param>
    /// <param name="second">���̉摜</param>
    public void InitSprite(Sprite first, Sprite second = null, Sprite third = null) //������ = null ������̂͂Ȃ��Ă����v�Ȃ悤�ɁI
    {
        _spriteLists.Add(first);    //�\�̉摜���i�[
        if (null != second) //�\��invisible�ł͂Ȃ���������ꍇ
            _spriteLists.Add(second);
        if (null != third) //�S�[��������ꍇ
            _spriteLists.Add(third);
        _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];   //�\�̉摜���C���[�W��\��
    }

    /// <summary>
    /// ���]�������̃C���[�W�ύX
    /// </summary>
    public void TurnImage()
    {
        if (_isEnableTurn)   //���]���邱�Ƃ��o����ꍇ
        {
            if (EnableCount <= 0)   //�c��̔��]�ł���񐔂��O�������ꍇ�͔��]�ł��Ȃ�������ɉ��������Ԃ�
            {
                _isEnableTurn = false;
                return;
            }

            if (TurnFaceType.Front == _turnFaceType)    //���݂̃C���[�W���\�Ɠ�����������i���ɂЂ�����Ԃ��ꍇ�j
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Back];    //���݂̃C���[�W�𗠂̉摜�ɂ���
                _turnFaceType = TurnFaceType.Back;  //���݂̏�Ԃ𗠂ɂ���
            }
            else  //���݂̃C���[�W�����Ɠ�����������(�\�ɂЂ�����Ԃ��ꍇ) ���S�[���p
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Front];   //���݂̃C���[�W��\�̉摜�ɂ���
                _turnFaceType = TurnFaceType.Front; //���݂̏�Ԃ�\�ɂ���
            } 
            EnableCount--;  //���̃^�C���̔��]�ł���񐔂����炷
        }
    }
    public void GoolChange()
    {
        if (TurnFaceType.Front == _turnFaceType)    //�\�������ꍇ�̂ݓǂݍ��ށ@�����ƌĂ΂Ȃ��@���łɃN���A�����𖞂������S�[���������ꍇ����΂Ȃ�
        {
            if (_spriteLists.Count != 3) //�O�ڂ̉摜�i�N���A�����𖞂�������Ԃ̃S�[��������ꍇ�j���Ȃ��ꍇ
                return;
            else
            {
                _mapImage.sprite = _spriteLists[(int)TurnFaceType.Goal];    //���݂̃C���[�W���N���A�����𖞂������S�[���̉摜�ɂ���
            }
        }
    }
}
