using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class MapData
{
    [Serializable]
    public class MapChip
    {
        public int mapImageID;    //�^�C����ID
        public Vector2 mapArray;    //�z����W
        public int turnCount;       //���]������
        public bool isTurnOver;     //���]�\�̗L��
        public bool isRope;         //���̃^�C���Ƀ��[�v�������Ă��邩
        public MapChip(Vector2 _mapArray,int Id,bool Rope, bool Turn)   //������
        {
            mapArray = _mapArray;
            mapImageID = Id;
            isRope = Rope;
            isTurnOver = Turn;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>�R���X�g���N�^</summary>
    public MapData(Vector2 _mapPos,int[] Id,bool[] Rope,bool[] Turn)
    {
        Vector2 _mapPosCount;
        int count = 0;
        //�e�^�C���Ɏ��g���z��̂ǂ̈ʒu�Ȃ̂��i�[����
        for (_mapPosCount.x = 0; _mapPosCount.x <= _mapPos.x; _mapPosCount.x++)
        {
            for (_mapPosCount.y = 0; _mapPosCount.y <= _mapPos.y; _mapPosCount.y++)
            {
                if (count == 56)
                    break;
                Map.Add(new MapChip(_mapPosCount,Id[count],Rope[count],Turn[count]));
                count++;
            }
        }
    }
}
