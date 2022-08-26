using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    public void test()
    {
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_02);
        SceneManager.LoadScene("GameScene");
    }
}
