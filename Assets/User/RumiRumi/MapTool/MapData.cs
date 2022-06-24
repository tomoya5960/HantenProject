using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MapData
{
    /// <summary> �}�b�v�̃`�b�v�ő吔 </summary>
    private readonly int _mapMaxCount = 56;

    [Serializable]
    public class MapChip
    {
        public int      mapImageID;         //�^�C����ID
        public int      turnCount;          //���]������
        public bool     isEnableRope;       //���̃^�C���Ƀ��[�v�������Ă��邩
        public bool      isEnableStone;     //���̃^�C���Ɋ₪�����Ă��邩
        public bool     isEnableProceed;    //�ʂ�邩

        public MapChip()   //������
        {
            mapImageID      = 0;
            turnCount       = 0;
            isEnableRope    = false;
            isEnableStone = false;
            isEnableProceed = true;
        }
    }

    public List<MapChip> Map = new List<MapChip>();

    /// <summary>�R���X�g���N�^</summary>
    public MapData()
    {
        foreach (var num in Enumerable.Range(0, _mapMaxCount))
        {
            Map.Add(new MapData.MapChip());
        }
    }
}
