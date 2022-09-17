using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScrollButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Scroll2;

    //��{�^������������X�N���[��
    public void Up()
    {
        Scroll2.GetComponent<Scroll>()._count--;
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

    //���{�^������������X�N���[��
    public void Down()
    {
        Scroll2.GetComponent<Scroll>()._count++;
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_03);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            GeneralManager.Instance.selectStageNum = 11;
            GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_02);
            SceneManager.LoadScene("GameScene");
        }
    }
}
