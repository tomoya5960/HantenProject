using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    public int stageNum = 0;    //ÉVÅ[ÉìÇÃî‘çÜ
    public void test()
    {
        switch(stageNum)
        {
            case 0:
                SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
                break;
            case 1:
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                break;
        }
    }
}
