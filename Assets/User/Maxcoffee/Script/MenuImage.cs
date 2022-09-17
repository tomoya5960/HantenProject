using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuImage : MonoBehaviour
{
    // 移動するスピード
    public float MoveSpeed = 0.01f;
    // 画像を差し替える速度
    [SerializeField,Tooltip("画像を差し替える速度")]
    private float fps = 0.1f;
    [SerializeField,Tooltip("画像を入れる場所")]
    private List<Sprite> sprites = new List<Sprite>();
    [SerializeField,Tooltip("目標地点")]
    private float destination = 1.5f;
    [SerializeField, Tooltip("目標地点2")]
    private float destination2 = 2f;
    private SpriteRenderer _spriterenderer;
    public bool Imagemenu = false;
    private bool CloseBottun = false;
    private bool OpenBottun = false;
    // コルーチンの実行が終わったのかの判定
    [SerializeField, Tooltip("コルーチン終了判定")]
    private bool isColl = false;
    // 何回押されたかの判定
    [SerializeReference]
    private int countbt = 0;
   
    void Start()
    {
        _spriterenderer = this.GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        
        if (OpenBottun && !CloseBottun)
        {
            if (transform.position.x > destination)
            {
                transform.position = new Vector3(transform.position.x - MoveSpeed, transform.position.y, transform.position.z);
                Imagemenu = true;
            }
            else if (!isColl)
            {
                StartCoroutine("OpenMune");
                isColl = true;
            }
            if (OpenBottun && Imagemenu && isColl)
            {
                OpenBottun = false;
                
            }
        }
        else if (CloseBottun && !OpenBottun)
        {
            if (!Imagemenu)
            {
                StartCoroutine("OpenMune");
            }
            else if (Imagemenu && isColl && destination2 > transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + MoveSpeed, transform.position.y, transform.position.z);
            }
            else if (CloseBottun && Imagemenu && isColl)
            {
                CloseBottun = false;
                countbt = 0;
            }
        }   
    }

    // ボタン押したときの処理
    public void OpenMenuBota()
    {
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_09);
        GeneralManager.Instance.isPlay = false;
        countbt++;
        if (countbt == 1)
        {
            OpenBottun = true;
            Imagemenu = false;
            isColl = false;

        }
        else
        {
            countbt--;
        }
    }
    public void CloseMenuBota()
    {
        GeneralManager.Instance.soundManager.PlaySE(SoundManager.SeName.se_09);
        GeneralManager.Instance.isPlay = true;
        countbt++;
        if (countbt == 2)
        {
            CloseBottun = true;
            Imagemenu = false;
            isColl = false;
        }
        else
        {
            countbt--;
        }
    }
    
    IEnumerator OpenMune()
    {
        isColl = false;
        Imagemenu = true;
        foreach (var num in sprites)
        {
            _spriterenderer.sprite = num;
            yield return new WaitForSeconds(fps);
        }
       
        isColl = true;
        sprites.Reverse();
        yield break;
    }
}
