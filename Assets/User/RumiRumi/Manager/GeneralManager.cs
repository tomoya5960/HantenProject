using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(MapType))]
[RequireComponent(typeof(MapManager))]

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance = null;   //ゲームマネージャは一つしかないよっていうやつ
    //[HideInInspector]
    public bool isEnablePlay = true;  //行動できるかどうか
    [HideInInspector]
    public        SoundManager   soundManager;       //SoundManagerを格納するやつだ！！
    [HideInInspector]
    public        MapType        mapType;            //MapTypeを格納するやつだ！！！
    [HideInInspector]
    public        MapManager   mapManager;

    private void Awake()    //スタートの前に呼び出すよ
    {
        if (instance == null)    //もしゲームマネージャーがなかった場合に呼ぶよ
        {
            instance = this;    //こいつが世界に一つのマネージャーになるよ
            DontDestroyOnLoad(this.gameObject); //このオブジェクトは消せねえ！ってするやつ
        }
        else
            Destroy(this.gameObject);
        soundManager = GetComponent<SoundManager>(); //SoundManagerを管理するぜ！！
        mapType = GetComponent<MapType>(); //MapTypeを管理するぜ！！
        mapManager = GetComponent<MapManager>();

    }
    private void Update()
    {
        #region ゲームのtitle移動/終了
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
        if(Input.GetKey(KeyCode.Tab))
#if UNITY_EDITOR
            SceneManager.LoadScene("MaxcoffeeScene");
#endif
        #endregion
    }
}
