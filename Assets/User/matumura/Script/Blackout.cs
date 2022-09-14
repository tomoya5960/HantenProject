using UnityEngine;
using UnityEngine.UI; //�p�l���̃C���[�W�𑀍삷��̂ɕK�v
using UnityEngine.SceneManagement;

public class Blackout : MonoBehaviour
{
    public bool isFadeOut = false; //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    public bool isFadeIn = true; //�t�F�[�h�C�������̊J�n�A�������Ǘ�����t���O

    public int _stageNum;    //�X�e�[�W�I���Ŏg���ϐ�

    public  float fadeSpeed = 0.003f; //�����x���ς��X�s�[�h���Ǘ�
    private float alfa; //�p�l���̐F�A�s�����x���Ǘ�

    private Image fadeImage; //�����x��ύX����p�l���̃C���[�W

    //Start������ɌĂ΂�邭��
    private void Awake()
    {
        fadeImage = GetComponent<Image>();  //�C���[�W��FadeImage�Ɋi�[�����
    }

    void Start()
    {
        alfa = fadeImage.color.a;   //�A���t�@�l���������悤�ɂ����
    }

    void Update()
    {

        if (isFadeIn)   //isFadeIN��true��������
        {
            StartFadeIn();  //�t�F�[�h�C������
        }
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }


    /// <summary>
    /// �ŏ��Ƀt�F�C�h�C������֐�
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeed; //a)�s�����x�����X�ɉ�����
        SetAlpha(); //b)�ύX�����s�����x�p�l���ɔ��f����
        if (alfa <= 0)
        { 
            //c)���S�ɓ����ɂȂ����珈���𔲂���
            isFadeIn = false;
            fadeImage.enabled = false;//d)�p�l���̕\�����I�t�ɂ���
        }
    }

    /// <summary>
    /// �ŏ��Ƀt�F�C�h�A�E�g����֐�
    /// </summary>
    void StartFadeOut()
    {
        fadeImage.enabled = true; // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed; // b)�s�����x�����X�ɂ�����
        SetAlpha(); // c)�ύX���������x���p�l���ɔ��f����
        if (alfa >= 1)
        { // d)���S�ɕs�����ɂȂ����珈���𔲂���
            isFadeOut = false;
            SceneChange();
        }
    }

    /// <summary>
    /// �A���t�@�l�̐ݒ�
    /// </summary>
    void SetAlpha()
    {
        fadeImage.color = new Color(0, 0, 0, alfa);   //�C���[�W�̃J���[���i�[
    }

    /// <summary>
    /// �X�e�[�W�I�����ꂽ���Ƃ��擾
    /// </summary>
    public void isPush()
    {
        isFadeOut = true;
    }

    /// <summary>
    /// �V�[���̈ړ�
    /// </summary>
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}