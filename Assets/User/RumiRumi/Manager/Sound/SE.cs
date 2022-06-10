using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public enum SeName    //BGM�̎��
    {
        //�Ȍ�ǉ�
        se_01,
        se_02,
        se_03,      
        se_04,
        se_05,
        se_06,
        se_07,
        se_08,
        se_09,
        se_10,
        se_11,
        se_12,
        se_13,
        se_14,
    }

    private       AudioSource    seSource;
    public        List<SeStatus> SeClips;
    private int[]                seNumber;   //SeName�̍��ڐ��̎擾
    [System.Serializable]
    public struct SeStatus  //���X�g���
    {
        [Header("���O")]
        public       SeName    name;
        [Header("����"), Range(0, 1)]
        public float           volume;
        [Header("SE�f�[�^")]
        public       AudioClip seData; //BGM�ꗗ
    }

    private void Awake()
    {
        seSource = gameObject.AddComponent<AudioSource>();
    }
    private void Start()
    {
        string[] var = System.Enum.GetNames(typeof(SeName));    //string[]��int[]�ɕϊ�
        seNumber = new int [var.Length];    //int�ɕϊ�

    }

    /// <summary>
    /// �Đ��֐�
    /// </summary>
    /// <param name="seName">�I������SE</param>
    public void PlaySE(SeName seName)
    {
        int index = (int)seName;    //�I�����ꂽSE�ԍ����i�[
        if (index < 0 || seNumber.Length <= index)  //�I�����ꂽSE�ԍ������邩�m�F�F������PlaySE���Ăяo���ꂽ�ۂ̃G���[���
        {
            Debug.LogWarning("�����ł��Ȃ�������");
            return;
        }
        seSource.clip = SeClips[index].seData;    //�Đ�����SE��I��
        seSource.volume = SeClips[index].volume;  //���ʂ𒲐������[
        seSource.Play();    //�Đ������[
        return;
    }

    /// <summary>
    /// SE��~�֐�
    /// </summary>
    public void StopSE()
    {

        seSource.Stop();    //���ׂĂ�SE���~

        return;
    }
}
