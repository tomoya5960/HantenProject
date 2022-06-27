using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum direction  //ˆÚ“®‚·‚é•ûŒü
    {
        up = 0,
        down,
        left,
        right,
    }
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
        #region ˆÚ“®
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!playerManager.isPlayerMove)
                playerManager.SearchMove((int)direction.up);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!playerManager.isPlayerMove)
                playerManager.SearchMove((int)direction.down);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!playerManager.isPlayerMove)
                playerManager.SearchMove((int)direction.left);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!playerManager.isPlayerMove)
                playerManager.SearchMove((int)direction.right);
        }
        #endregion


    }
}
