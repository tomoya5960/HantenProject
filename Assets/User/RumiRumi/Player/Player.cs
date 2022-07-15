using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Sprite> spriteLists = new List<Sprite>();    //タイルのイメージ画像（表裏）
    private SpriteRenderer _playerSprite;

    public enum direction  //移動する方向
    {
        Up = 0,
        Down,
        Left,
        Right,
    }
    private PlayerManager _playerManager;
    [HideInInspector]
    public direction dic;

    

    private void Awake()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerManager = gameObject.GetComponent<PlayerManager>();
        GeneralManager.instance.mapManager.player = GetComponent<PlayerManager>();
    }
    private void Start()
    {
        dic = direction.Down;
    }
    void Update()
    {
        #region 移動
        if (!_playerManager.isPlayerMove && GeneralManager.instance.isEnablePlay == true)
        {
            #region 斜め禁止
            if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
                return;
            if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
                return;
            if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
                return;
            if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
                return;
            #endregion

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                Move(direction.Up);
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                Move(direction.Down);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                Move(direction.Left);
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                Move(direction.Right);
        }
        #endregion
    }

    /// <summary>
    /// 各移動処理の発動
    /// </summary>
    /// <param name="playerDic">進む方向</param>
    private void Move(direction playerDic)
    {
        GeneralManager.instance.isEnablePlay = false;
        dic = playerDic;
        ChangePlayerSprite(dic);
        do
        {
            _playerManager.SetPlayerPos((int)playerDic);
        } while (GeneralManager.instance.mapManager.IsIceFloor((int)playerDic));

       // ChangePlayerSprite(dic);
        GeneralManager.instance.mapManager.SetBeforeStageData();
        GeneralManager.instance.isEnablePlay = true;
    }

    public void ChangePlayerSprite(direction playerDic)
    {
        if(_playerSprite.sprite != spriteLists[(int)playerDic])
            _playerSprite.sprite = spriteLists[(int)playerDic];
    }
}
