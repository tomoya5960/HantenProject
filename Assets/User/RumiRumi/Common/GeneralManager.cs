using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(StageSetting))]
public class GeneralManager : MonoBehaviour
{
                      public static GeneralManager Instance = null;
    [HideInInspector] public        SoundManager   soundManager;
    [HideInInspector] public        StageSetting stageSetting;
    [HideInInspector] public        MapType        mapType;
    
                      public int    selectStageNum;                 //ステージ番号 :この番号に対応したステージを遊ぶ
    [HideInInspector] public bool   isPlay;                         //行動してもよいか
    private void Awake()
    {
        //FPSを60に固定
        Application.targetFrameRate =60;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
        
        soundManager = GetComponent<SoundManager>();
        stageSetting = GetComponent<StageSetting>();
    }

    private void Update()
    {
        #region ゲームのtitle移動/終了
            //ゲーム終了
            if (Input.GetKey(KeyCode.Escape))
            {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
            }
            //タイトルに移動
            if (Input.GetKey(KeyCode.Backspace))
            {
#if UNITY_EDITOR
            SceneManager.LoadScene("MaxcoffeeScene");
#else
                SceneManager.LoadScene("MaxcoffeeScene");
#endif
            }

            #endregion
    }
}
