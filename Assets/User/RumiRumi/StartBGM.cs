using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BgmName    //BGM‚ÌŽí—Þ
{
    //ˆÈŒã’Ç‰Á
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
        GeneralManager.instance.soundManager.PlayBGM((SoundManager.BgmName)bgm);
    }

}
