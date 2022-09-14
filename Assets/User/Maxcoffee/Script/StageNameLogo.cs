using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageNameLogo : MonoBehaviour
{
    public float fps = 0.2f;
    public float read = 1.0f;
    public float MoveSpeed = 0.1f;
    [SerializeField,Header("最初の画像")] 
    private Sprite firstSprite;
    
    public List<SpriteInfo> logoInfos;
    private List<Sprite> useSpriteList = new List<Sprite>();
    
    [System.Serializable]
    public struct SpriteInfo  //リスト情報
    {
        [Header("名前")]
        public string stageName;
        public List<Sprite> logoSprites;

    }
    
    public Transform startMarker; //現在の位置
    public Transform endMarker;
    private float distance_two;
    public float present_Location;
    private SpriteRenderer sprite;
    private bool test;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (useSpriteList.Count > GeneralManager.Instance.selectStageNum || GeneralManager.Instance.selectStageNum != 0 )
        {
            callCoroutine();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (test && present_Location <= 1)
        {
            // 現在の位置
            present_Location = (Time.time * MoveSpeed) / distance_two;
            // オブジェクトの移動
            transform.localPosition = Vector3.Lerp(startMarker.localPosition, endMarker.localPosition, present_Location);
        }
    }
    public void callCoroutine()
    {
        if (GeneralManager.Instance.selectStageNum < 11)
            StartCoroutine("RopeAnim");
        else
            gameObject.Equals(false);

    }
    private IEnumerator RopeAnim()
    {
        int count = 0;
        useSpriteList = logoInfos[GeneralManager.Instance.selectStageNum].logoSprites;
        distance_two = Vector3.Distance(startMarker.localPosition, endMarker.localPosition);
        while (count < useSpriteList.Count)
        {
            Sprite nextSprite = useSpriteList[count];
            sprite.sprite = nextSprite;
            yield return new WaitForSeconds(fps);
            count++;
        }
        
        yield return new WaitForSeconds(2);
        
        while (count > 0)
        {
            Sprite nextSprite = useSpriteList[count -1];
            sprite.sprite = nextSprite;
            yield return new WaitForSeconds(fps);
            count--;
        }

        sprite.sprite = firstSprite;
        test = true;
    }
}
