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
        if (!_playerManager.isPlayerMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(direction.Up);
                
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(direction.Down);
                
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(direction.Left);
                
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(direction.Right);
            }
        }
        #endregion
    }

    /// <summary>
    /// 各移動処理の発動
    /// </summary>
    /// <param name="playerDic">進む方向</param>
    private void Move(direction playerDic)
    {
        do
        {
            if (dic != playerDic)
            {
                dic = playerDic;
                ChangePlayerSprite(dic);
            }
            _playerManager.SetPlayerPos((int)playerDic);
        } while (GeneralManager.instance.mapManager.IsIceFloor((int)playerDic));
        GeneralManager.instance.mapManager.SetBeforeStageData();
    }

    public void ChangePlayerSprite(direction playerDic)
    {
        _playerSprite.sprite = spriteLists[(int)playerDic];
    }
}
