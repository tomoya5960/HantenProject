using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("���]�\��")]
    public int turnOverCount = 0;   //���]�ł���c��̉�
    [SerializeField, Header("�X�e�[�W��")]
    private  string stageName = ""; //JsonOnlyJson�̃X�e�[�W�����i�[����
    private GameObject loadOnlyJsonObject;  //�X�e�[�W�����i�[����Ă��邽�ߎ擾���邽�߂Ɏg����[��

    #region MAP�̓񎟌��z��
    public  MapPosition[] mapPosX = new MapPosition[7];
    [System.Serializable]
    public class MapPosition
    {
        public GameObject[] mapPosY = new GameObject[8];
    }
    #endregion

    private void Awake()
    {
        loadOnlyJsonObject = GameObject.Find("LoadData");
    }
    private void Start()
    {
        if (loadOnlyJsonObject != null)
            stageName = loadOnlyJsonObject.GetComponent<LoadOnlyJson>().loadFileName;
        else
            stageName = "�G�f�B�^�[�ŕҏW��";
    }

    /// <summary>
    /// ���]����
    /// </summary>
    public void TurnOver()
    {
        if (turnOverCount != 0) //���]�񐔂��c���Ă�����c��̎g�p�񐔂����炷
        {
            turnOverCount--;
            Debug.Log("���]���܂����B");
        }
        else
        {
            Debug.Log("���]�ł��܂���");
            return; //���]�ł���񐔂��c���Ă��Ȃ��ꍇ�͂��̂܂ܕԂ�
        }
    }
}
