using UnityEngine;
using UnityEngine.UI; //パネルのイメージを操作するのに必要
using UnityEngine.SceneManagement;

public class Blackout : MonoBehaviour
{
    public bool isFadeOut = false; //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = true; //フェードイン処理の開始、完了を管理するフラグ

    public int _stageNum;    //ステージ選択で使う変数

    public  float fadeSpeed = 0.003f; //透明度が変わるスピードを管理
    private float alfa; //パネルの色、不透明度を管理

    private Image fadeImage; //透明度を変更するパネルのイメージ

    //Startよりも先に呼ばれるくん
    private void Awake()
    {
        fadeImage = GetComponent<Image>();  //イメージをFadeImageに格納するよ
    }

    void Start()
    {
        alfa = fadeImage.color.a;   //アルファ値をいじれるようにするよ
    }

    void Update()
    {

        if (isFadeIn)   //isFadeINがtrueだったら
        {
            StartFadeIn();  //フェードインする
        }
        if (isFadeOut)
        {
            StartFadeOut();
        }
    }


    /// <summary>
    /// 最初にフェイドインする関数
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeed; //a)不透明度を徐々に下げる
        SetAlpha(); //b)変更した不透明度パネルに反映する
        if (alfa <= 0)
        { 
            //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;//d)パネルの表示をオフにする
        }
    }

    /// <summary>
    /// 最初にフェイドアウトする関数
    /// </summary>
    void StartFadeOut()
    {
        fadeImage.enabled = true; // a)パネルの表示をオンにする
        alfa += fadeSpeed; // b)不透明度を徐々にあげる
        SetAlpha(); // c)変更した透明度をパネルに反映する
        if (alfa >= 1)
        { // d)完全に不透明になったら処理を抜ける
            isFadeOut = false;
            SceneChange();
        }
    }

    /// <summary>
    /// アルファ値の設定
    /// </summary>
    void SetAlpha()
    {
        fadeImage.color = new Color(0, 0, 0, alfa);   //イメージのカラーを格納
    }

    /// <summary>
    /// ステージ選択されたことを取得
    /// </summary>
    public void isPush()
    {
        isFadeOut = true;
    }

    /// <summary>
    /// シーンの移動
    /// </summary>
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}