using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public enum BgmName    //BGM�̎��
    {
        //�Ȍ�ǉ�
        bgm_01,
        bgm_02,
        bgm_03,
        bgm_04,
        Silent = 999,
    }

    private AudioSource bgmSource;
    public List<BgmStatus> BgmClips;
    private int[] bgmNumber;   //BgmName�̍��ڐ��̎擾

    [System.Serializable]
    public struct BgmStatus  //���X�g���
    {
        [Header("���O")]
        public BgmName name;
        [Header("����"), Range(0, 1)]
        public float volume;
        [Header("BGM�f�[�^")]
        public AudioClip bgmData; //BGM�ꗗ
    }

    private int currentBgmIndex = 999;  //���ݑI�΂�Ă���BGM�ԍ�
    private void Awake()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
    }
    private void Start()
    {
        string[] var = System.Enum.GetNames(typeof(BgmName));    //string[]��int[]�ɕϊ�
        bgmNumber = new int[var.Length];    //int�ɕϊ�

    }

    /// <summary>
    /// �Đ��֐�
    /// </summary>
    /// <param name="bgmName">�I������BGM</param>
    public void PlayBGM(BgmName bgmName, bool loopFlg = true)
    {
        int index = (int)bgmName;    //�I�����ꂽBGM�ԍ����i�[
        currentBgmIndex = index;    //�I�����ꂽBGM�ԍ����Đ�����ׂ̕ϐ��Ɋi�[
        if (index == 999) //�����ɂ���Ƃ��̂��
        {
            Debug.LogWarning("�����ɂȂ�����");
            StopBGM();  //����BGM�����ׂăX�g�b�v�������
            return;
        }
        #region �G���[���p
        if (index < 0 || bgmNumber.Length <= index)  //�I�����ꂽBGM�ԍ������邩�m�F�F������PlayBGM���Ăяo���ꂽ�ۂ̃G���[���
        {
            Debug.LogWarning("�����ł��Ȃ�������");
            return;
        }
        else if (bgmSource.clip != null && bgmSource.clip == BgmClips[index].bgmData) // ����BGM�̏ꍇ�͉������Ȃ�
        {

            Debug.LogWarning("BGM��������������");
            return;
        }
        #endregion
        else if (!bgmSource.isPlaying)  //�Đ�����Ă��Ȃ�������
        {
            bgmSource.clip = BgmClips[index].bgmData;    //�Đ�����BGM��I��
            bgmSource.volume = BgmClips[index].volume;  //���ʂ𒲐������[
            bgmSource.Play();    //�Đ������[
            return;
        }
    }

    /// <summary>
    /// BGM��~�֐�
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();    //���ׂĂ�BGM���~
        return;
    }

    /// <summary>
    /// BGM�ꎞ��~
    /// </summary>
    public void MuteBGM()
    {
        bgmSource.Stop(); //BGM���ꎞ��~�`
    }

    /// <summary>
    /// �~�߂�BGM���ĊJ����֐�
    /// </summary>
    public void ResumeBGM()
    {
        bgmSource.Play(); //�~�߂�BGM���Đ��`
    }
}
