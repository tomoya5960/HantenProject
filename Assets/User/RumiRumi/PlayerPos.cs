using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    void Start()
    {
        GeneralManager.instance.mapManager.PlayerPos = transform.parent.gameObject.GetComponent<TileData>().tilePos;
    }
}
