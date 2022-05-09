using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData
{
    public enum MapTile    //�^�C���̎��
    {
        clearTile,
        OuterWall,              //�O��
        WhitePassage,           //���ʘH
        WhiteWall,              //����
        BlackPassage,           //���ʘH
        BlackWall,              //����
        IcePassage,             //�X�ʘH
        IceWall,                //�X��
        Rope,                   //���[�v
        Goal,                   //�S�[��
        GoalWithRope,           //���[�v�t���S�[��
        StoneMonument,          //�Δ�
        StoneStatueUp,          //�Α�(��)
        StoneStatueDown,        //�Α�(��)
        StoneStatueLeft,        //�Α�(��)
        StoneStatueRight,       //�Α�(��)
        BrokenStoneStatueUp,    //��ꂽ�Α�(��)
        BrokenStoneStatueDown,  //��ꂽ�Α�(��)
        BrokenStoneStatueLeft,  //��ꂽ�Α�(��)
        BrokenStoneStatueRight, //��ꂽ�Α�(�E)
    }

    [Serializable]
    public class MapChip
    {
        [Header("�^�C���^�C�v")]
        public MapTile mapTile;     //�^�C���̎��
        public Vector2 mapArray;    //�z����W
        public int turnCount;       //���]������
        public bool isTurnOver;     //���]�\�̗L��
        public bool isRope;         //���̃^�C���Ƀ��[�v�������Ă��邩

        public MapChip(Vector2 _mapArray)   //������
        {
            mapArray = _mapArray;
            turnCount = 0;
            isTurnOver = false;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>�R���X�g���N�^</summary>
    /// <param name="_mapPos">�z����W</param>
    public MapData(Vector2 _mapPos)
    {
        Vector2 _mapPosCount;
        //�e�^�C���Ɏ��g���z��̂ǂ̈ʒu�Ȃ̂��i�[����
        for (_mapPosCount.x = 0; _mapPosCount.x <= _mapPos.x; _mapPosCount.x++)
        {
            for (_mapPosCount.y = 0; _mapPosCount.y <= _mapPos.y; _mapPosCount.y++)
            {
                Map.Add(new MapData.MapChip(_mapPosCount));
            }
        }
    }
}
