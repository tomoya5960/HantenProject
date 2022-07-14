using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region BGM
    public enum BgmName    //BGM�̎��
    {
        //�Ȍ�ǉ�
        bgm_01 = 0,
        bgm_02,
        bgm_03,
        bgm_04,
        Silent = 999,
    }
    [HideInInspector]
    public BgmName bgm;
    private       AudioSource     _bgmSource;
    public        List<BgmStatus> bgmClips;
    private int[]                 _bgmNumber;   //BgmName�̍��ڐ��̎擾
    private int                   _currentBgmIndex = 999;  //���ݑI�΂�Ă���BGM�ԍ�

    [System.Serializable]
    public struct BgmStatus  //���X�g���
    {
        [Header("���O")]
        public BgmName Name;
        [Header("����"), Range(0, 1)]
        public float Volume;
        [Header("BGM�f�[�^")]
        public AudioClip BgmData; //BGM�ꗗ
    }



    /// <summary>
    /// �Đ��֐�
    /// </summary>
    /// <param name="bgmName">�I������BGM</param>
    public void PlayBGM(BgmName bgmName, bool loopFlg = true)
    {
        
        int index = (int)bgmName;    //�I�����ꂽBGM�ԍ����i�[
        _currentBgmIndex = index;    //�I�����ꂽBGM�ԍ����Đ�����ׂ̕ϐ��Ɋi�[
        if (index == 999) //�����ɂ���Ƃ��̂��
        {
            Debug.LogWarning("�����ɂȂ�����");
            StopBGM();  //����BGM�����ׂăX�g�b�v�������
            return;
        }
        #region �G���[���p
        if (index < 0 || _bgmNumber.Length <= index)  //�I�����ꂽBGM�ԍ������邩�m�F�F������PlayBGM���Ăяo���ꂽ�ۂ̃G���[���
        {
            Debug.LogWarning("�����ł��Ȃ�������");
            return;
        }
        else if (_bgmSource.clip != null && _bgmSource.clip == bgmClips[index].BgmData) // ����BGM�̏ꍇ�͉������Ȃ�
        {

            Debug.LogWarning("BGM��������������");
            _bgmSource.Play();
            return;
        }
        #endregion
        else if (!_bgmSource.isPlaying)  //�Đ�����Ă��Ȃ�������
        {
            _bgmSource.clip = bgmClips[index].BgmData;    //�Đ�����BGM��I��
            _bgmSource.volume = bgmClips[index].Volume;  //���ʂ𒲐������[
            _bgmSource.Play();    //�Đ������[
            return;
        }
        StopBGM();
    }

    /// <summary>
    /// BGM��~�֐�
    /// </summary>
    public void StopBGM()
    {
        _bgmSource.Stop();    //���ׂĂ�BGM���~
        return;
    }

    /// <summary>
    /// BGM�ꎞ��~
    /// </summary>
    public void MuteBGM()
    {
        _bgmSource.Stop(); //BGM���ꎞ��~�`
    }

    /// <summary>
    /// �~�߂�BGM���ĊJ����֐�
    /// </summary>
    public void ResumeBGM()
    {
        _bgmSource.Play(); //�~�߂�BGM���Đ��`
    }

    #endregion

    #region  SE

    public enum SeName
    {
        se_01 = 0,
        se_01_2,
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
        se_14
    }

    private       AudioSource    _seSource;
    public        List<SeStatus> seClips;
    private int[]                _seNumber;   //SeName�̍��ڐ��̎擾
    [System.Serializable]
    public struct SeStatus  //���X�g���
    {
        [Header("���O")]
        public SeName Name;
        [Header("����"), Range(0, 1)]
        public float Volume;
        [Header("SE�f�[�^")]
        public AudioClip SeData; //BGM�ꗗ
    }

    /// <summary>
    /// �Đ��֐�
    /// </summary>
    /// <param name="seName">�I������SE</param>
    public void PlaySE(SeName seName)
    {
        int index = (int)seName;    //�I�����ꂽSE�ԍ����i�[
        if (index < 0 || _seNumber.Length <= index)  //�I�����ꂽSE�ԍ������邩�m�F�F������PlaySE���Ăяo���ꂽ�ۂ̃G���[���
        {
            Debug.LogWarning("�����ł��Ȃ�������");
            return;
        }
        _seSource.clip = seClips[index].SeData;    //�Đ�����SE��I��
        _seSource.volume = seClips[index].Volume;  //���ʂ𒲐������[
        _seSource.Play();
        return;
    }

    /// <summary>
    /// SE��~�֐�
    /// </summary>
    public void StopSE()
    {

        _seSource.Stop();    //���ׂĂ�SE���~

        return;
    }

    #endregion

    private void Awake()
    {
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _seSource = gameObject.AddComponent<AudioSource>();

        string[] BGM = System.Enum.GetNames(typeof(BgmName));    //string[]��int[]�ɕϊ�
        _bgmNumber = new int[BGM.Length];    //int�ɕϊ�

        string[] SE = System.Enum.GetNames(typeof(SeName));    //string[]��int[]�ɕϊ�
        _seNumber = new int[SE.Length];    //int�ɕϊ�
    }
}
