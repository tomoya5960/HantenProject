using UnityEngine;

public class Player : MonoBehaviour
{
    
    private enum direction  //ˆÚ“®‚·‚é•ûŒü
    {
        Up = 0,
        Down,
        Left,
        Right,
        Default,
    }
    private PlayerManager _playerManager;

    private void Awake()
    {
        _playerManager = gameObject.GetComponent<PlayerManager>();
        GeneralManager.instance.mapManager.player = GetComponent<PlayerManager>();
    }

    void Update()
    {
        #region ˆÚ“®
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
    /// ŠeˆÚ“®ˆ—‚Ì”­“®
    /// </summary>
    /// <param name="dic">i‚Ş•ûŒü</param>
    private void Move(direction dic)
    {
        do
        {
            _playerManager.SetPlayerPos((int)dic);
        } while (GeneralManager.instance.mapManager.IsIceFloor((int)dic));
        GeneralManager.instance.mapManager.SetBeforeStageData();
    }
}
