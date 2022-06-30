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
    }

    void Update()
    {
        #region ˆÚ“®

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            do
            {
                _playerManager.SetPlayerPos((int)direction.Up);
                if (!_playerManager.isHaveRope)
                    _playerManager.isHaveRope = GeneralManager.instance.mapManager.isUnderRope();
            } while (GeneralManager.instance.mapManager.IsIceFloor((int)direction.Up));
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            do
            {
                _playerManager.SetPlayerPos((int)direction.Down);
                if (!_playerManager.isHaveRope)
                    _playerManager.isHaveRope = GeneralManager.instance.mapManager.isUnderRope();
            } while (GeneralManager.instance.mapManager.IsIceFloor((int)direction.Down));

        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            do
            {
                _playerManager.SetPlayerPos((int)direction.Left);
                if (!_playerManager.isHaveRope)
                    _playerManager.isHaveRope = GeneralManager.instance.mapManager.isUnderRope();
            } while (GeneralManager.instance.mapManager.IsIceFloor((int)direction.Left));
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            do
            {
                _playerManager.SetPlayerPos((int)direction.Right);
                if (!_playerManager.isHaveRope)
                    _playerManager.isHaveRope = GeneralManager.instance.mapManager.isUnderRope();
            } while (GeneralManager.instance.mapManager.IsIceFloor((int)direction.Right));
        }
        #endregion
    }
}
