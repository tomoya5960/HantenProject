using UnityEngine;
using UnityEngine.SceneManagement;

public enum BgmName    //BGM
{
    bgm_01 = 0,
    bgm_02,
    bgm_03,
    bgm_04,
    Silent = 999,
}
public class StartBGM : MonoBehaviour
{
    [SerializeField]
    private BgmName bgm;
    
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "MaxcoffeeScene")
        GeneralManager.Instance.soundManager.StopBGM();
        GeneralManager.Instance.soundManager.PlayBGM((SoundManager.BgmName)bgm);
    }

}
