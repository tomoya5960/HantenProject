using System;
using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [Header("���̃^�C���̃C���[�WID")]
    public  int              imageID;
    [HideInInspector]
    public Vector2 tilePos;
    [Header("���]�ł��邩")]
    public  bool             isTurnOver;        //�^�C���̔��]�\���̗L��
    [HideInInspector]
    public  bool             isEnableRope;      //���̃^�C���Ƀ��[�v�������Ă��邩
    [Header("�₪���邩")]
    public bool              isEnableStone;
    [HideInInspector]
    public bool isEnablePlayer;
    [Header("�ʂ邱�Ƃ͂ł��邩")]
    public  bool             isEnableProceed;   //�ʂ邱�Ƃ��ł��邩
    [HideInInspector]
    public int               childCount;
    [HideInInspector]
    public       GameObject  child;         //�q�I�u�W�F�N�g�̊i�[
    private bool _isActiveself = true;
    [HideInInspector]
    public bool isActiveself
    {
        get { return _isActiveself; }
        set
        {
            if (gameObject.transform.childCount > 1)
            {
                _isActiveself = value;
                transform.GetChild(1).gameObject.SetActive(_isActiveself);
            }
            else
                return;
        }
    }

    //---------------------------------------------------------------------------------
    public TileMaster.TurnFaceType _turnFaceType;
    public bool isEnableTurn;
}
