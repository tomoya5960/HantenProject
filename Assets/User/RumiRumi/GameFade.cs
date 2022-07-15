using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �t�F�[�h���Ǘ�����N���X
/// </summary>
public sealed class GameFade : MonoBehaviour
{
    public static GameFade instance = null;   //�Q�[���}�l�[�W���͈�����Ȃ�����Ă������

    public Image m_image = null;
    private void Awake()    //�X�^�[�g�̑O�ɌĂяo����
    {
        if (instance == null)    //�����Q�[���}�l�[�W���[���Ȃ������ꍇ�ɌĂԂ�
        {
            instance = this;    //���������E�Ɉ�̃}�l�[�W���[�ɂȂ��
            DontDestroyOnLoad(this.gameObject); //���̃I�u�W�F�N�g�͏����˂��I���Ă�����
        }
        else
            Destroy(this.gameObject);
    }

    /// <summary>
    /// �K��l�ɖ߂�
    /// </summary>
    private void Reset()
    {
        m_image = GetComponent<Image>();
    }

    /// <summary>
    /// �t�F�[�h�C������
    /// </summary>
    public void FadeIn(float duration, Action on_completed = null)
    {
        StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration, on_completed, true));
    }

    /// <summary>
    /// �t�F�[�h�A�E�g����
    /// </summary>
    public void FadeOut(float duration, Action on_completed = null)
    {
        StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration, on_completed));
    }

    /// <summary>
    /// ���Ԍo�߂ŃA���t�@�l���u0�v����u1�v�ɕύX
    /// </summary>
    private IEnumerator ChangeAlphaValueFrom0To1OverTime(
        float duration,
        Action on_completed,
        bool is_reversing = false
    )
    {
        GeneralManager.instance.isEnablePlay = false;
        if (!is_reversing) m_image.enabled = true;

        var elapsed_time = 0.0f;
        var color = m_image.color;

        while (elapsed_time < duration)
        {
            var elapsed_rate = Mathf.Min(elapsed_time / duration, 1.0f);
            color.a = is_reversing ? 1.0f - elapsed_rate : elapsed_rate;
            m_image.color = color;

            yield return null;
            elapsed_time += Time.deltaTime;
        }

        if (is_reversing) m_image.enabled = false;
        if (on_completed != null) on_completed();
        GeneralManager.instance.isEnablePlay = true;
        if (!is_reversing) SceneManager.LoadScene("Result");
    }
}