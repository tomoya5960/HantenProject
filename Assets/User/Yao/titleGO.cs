using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleGO : MonoBehaviour
{
    public void titleGo()
    {
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_02);
        SceneManager.LoadScene("MaxcoffeeScene");
    }
}
