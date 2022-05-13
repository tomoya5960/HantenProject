using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Player _player;

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) _player.MoveUp();
        if (Input.GetKey(KeyCode.S)) _player.MoveDown();
        if (Input.GetKey(KeyCode.A)) _player.MoveLeft();
        if (Input.GetKey(KeyCode.D)) _player.MoveRight();
    }
}
